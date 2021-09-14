cmake_minimum_required (VERSION 3.13)

project ("MKL.NET.Native")

if (CMAKE_BINARY_DIR MATCHES "x86$")
    set (COMPILE_OPTIONS "-m32")
    set (LINK_OPTIONS "-m32")
    set (CMAKE_GENERATOR_PLATFORM "Win32")
endif()
set (CMAKE_SHARED_LIBRARY_PREFIX "")
add_library (MKL.NET.Native SHARED "MKL.NET.Native.c")