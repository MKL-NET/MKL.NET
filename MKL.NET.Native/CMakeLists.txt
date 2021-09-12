cmake_minimum_required (VERSION 3.8)

project ("MKL.NET.Native")

set (CMAKE_SHARED_LIBRARY_PREFIX "")
add_library (MKL.NET.Native SHARED "MKL.NET.Native.c")