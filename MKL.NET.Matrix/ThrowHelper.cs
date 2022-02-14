// Copyright 2022 Anthony Lloyd
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Runtime.CompilerServices;

namespace MKLNET
{
    public static class ThrowHelper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void ThrowIncorrectDimensionsForOperation()
        {
            throw new Exception("Incorrect Dimensions For Operation");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Check(int i)
        {
            if (i != 0) throw new Exception("MKL Error code: " + i);
        }
    }
}
