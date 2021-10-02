// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// - Modified to use GC.AllocateArray

using System;
using System.Runtime.CompilerServices;
using System.Threading;

namespace MKLNET
{
    internal static class Utilities
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int SelectBucketIndex(int bufferSize)
        {
#if NETCOREAPP
            return System.Numerics.BitOperations.Log2((uint)bufferSize - 1 | 15) - 3;
#else
            int i = 0;
            while (GetMaxSizeForBucket(i) < bufferSize) i++;
            return i;
#endif
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int GetMaxSizeForBucket(int binIndex)
        {
            return 16 << binIndex;
        }
    }

    internal class ArrayPool<T>
    {
        /// <summary>The default maximum length of each array in the pool (2^20).</summary>
        internal const int DefaultMaxArrayLength = 1024 * 1024;
        /// <summary>The default maximum number of arrays per bucket that are available for rent.</summary>
        internal const int DefaultMaxNumberOfArraysPerBucket = 50;

        private readonly Bucket[] _buckets;

        internal ArrayPool(int maxArrayLength, int maxArraysPerBucket)
        {
            // Our bucketing algorithm has a min length of 2^4 and a max length of 2^30.
            // Constrain the actual max used to those values.
            const int MinimumArrayLength = 0x10, MaximumArrayLength = 0x40000000;
            if (maxArrayLength > MaximumArrayLength)
            {
                maxArrayLength = MaximumArrayLength;
            }
            else if (maxArrayLength < MinimumArrayLength)
            {
                maxArrayLength = MinimumArrayLength;
            }

            // Create the buckets.
            int maxBuckets = Utilities.SelectBucketIndex(maxArrayLength);
            var buckets = new Bucket[maxBuckets + 1];
            for (int i = 0; i < buckets.Length; i++)
            {
                buckets[i] = new Bucket(Utilities.GetMaxSizeForBucket(i), maxArraysPerBucket);
            }
            _buckets = buckets;
        }

        public T[] Rent(int minimumLength)
        {
            T[]? buffer;

            int index = Utilities.SelectBucketIndex(minimumLength);
            if (index < _buckets.Length)
            {
                // Search for an array starting at the 'index' bucket. If the bucket is empty, bump up to the
                // next higher bucket and try that one, but only try at most a few buckets.
                const int MaxBucketsToTry = 2;
                int i = index;
                do
                {
                    // Attempt to rent from the bucket.  If we get a buffer from it, return it.
                    buffer = _buckets[i].Rent();
                    if (buffer != null)
                    {
                        return buffer;
                    }
                }
                while (++i < _buckets.Length && i != index + MaxBucketsToTry);

                // The pool was exhausted for this buffer size.  Allocate a new buffer with a size corresponding
                // to the appropriate bucket.
#if NET5_0_OR_GREATER
                buffer = GC.AllocateArray<T>(_buckets[index]._bufferLength, true);
#else
                buffer = new T[_buckets[index]._bufferLength];
#endif
            }
            else
            {
                // The request was for a size too large for the pool.  Allocate an array of exactly the requested length.
                // When it's returned to the pool, we'll simply throw it away.
#if NET5_0_OR_GREATER
                buffer = GC.AllocateArray<T>(minimumLength, true);
#else
                buffer = new T[minimumLength];
#endif
            }

            return buffer;
        }

        public void Return(T[] array, bool clearArray = false)
        {
            // Determine with what bucket this array length is associated
            int bucket = Utilities.SelectBucketIndex(array.Length);

            // If we can tell that the buffer was allocated, drop it. Otherwise, check if we have space in the pool
            if (bucket < _buckets.Length)
            {
                // Clear the array if the user requests
                if (clearArray)
                {
                    Array.Clear(array, 0, array.Length);
                }

                // Return the buffer to its bucket.  In the future, we might consider having Return return false
                // instead of dropping a bucket, in which case we could try to return to a lower-sized bucket,
                // just as how in Rent we allow renting from a higher-sized bucket.
                _buckets[bucket].Return(array);
            }
        }

        /// <summary>Provides a thread-safe bucket containing buffers that can be Rent'd and Return'd.</summary>
        class Bucket
        {
            internal readonly int _bufferLength;
            private readonly T[]?[] _buffers;

            private SpinLock _lock; // do not make this readonly; it's a mutable struct
            private int _index;

            /// <summary>
            /// Creates the pool with numberOfBuffers arrays where each buffer is of bufferLength length.
            /// </summary>
            internal Bucket(int bufferLength, int numberOfBuffers)
            {
                _lock = new SpinLock(false);
                _buffers = new T[numberOfBuffers][];
                _bufferLength = bufferLength;
            }

            /// <summary>Gets an ID for the bucket to use with events.</summary>
            internal int Id => GetHashCode();

            /// <summary>Takes an array from the bucket.  If the bucket is empty, returns null.</summary>
            internal T[]? Rent()
            {
                T[]?[] buffers = _buffers;
                T[]? buffer = null;

                // While holding the lock, grab whatever is at the next available index and
                // update the index.  We do as little work as possible while holding the spin
                // lock to minimize contention with other threads.  The try/finally is
                // necessary to properly handle thread aborts on platforms which have them.
                bool lockTaken = false, allocateBuffer = false;
                try
                {
                    _lock.Enter(ref lockTaken);

                    if (_index < buffers.Length)
                    {
                        buffer = buffers[_index];
                        buffers[_index++] = null;
                        allocateBuffer = buffer == null;
                    }
                }
                finally
                {
                    if (lockTaken) _lock.Exit(false);
                }

                // While we were holding the lock, we grabbed whatever was at the next available index, if
                // there was one.  If we tried and if we got back null, that means we hadn't yet allocated
                // for that slot, in which case we should do so now.
                if (allocateBuffer)
                {
#if NET5_0_OR_GREATER
                    buffer = GC.AllocateArray<T>(_bufferLength, true);
#else
                    buffer = new T[_bufferLength];
#endif
                }

                return buffer;
            }

            /// <summary>
            /// Attempts to return the buffer to the bucket.  If successful, the buffer will be stored
            /// in the bucket and true will be returned; otherwise, the buffer won't be stored, and false
            /// will be returned.
            /// </summary>
            internal void Return(T[] array)
            {
                // While holding the spin lock, if there's room available in the bucket,
                // put the buffer into the next available slot.  Otherwise, we just drop it.
                // The try/finally is necessary to properly handle thread aborts on platforms
                // which have them.
                bool lockTaken = false;
                try
                {
                    _lock.Enter(ref lockTaken);

                    if (_index != 0)
                    {
                        _buffers[--_index] = array;
                    }
                }
                finally
                {
                    if (lockTaken) _lock.Exit(false);
                }
            }
        }
    }

    internal class Pool
    {
        internal static ArrayPool<int> Int = new(1024, 3);
    }
}