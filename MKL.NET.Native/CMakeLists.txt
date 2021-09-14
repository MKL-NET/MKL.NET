cmake_minimum_required (VERSION 3.8)

project ("MKL.NET.Native")

if (CMAKE_BINARY_DIR MATCHES "x86$")
    set (COMPILE_OPTIONS "-m32")
    set (LINK_FLAGS "-m32")
endif()
set (CMAKE_SHARED_LIBRARY_PREFIX "")
add_library (MKL.NET.Native SHARED "MKL.NET.Native.c")