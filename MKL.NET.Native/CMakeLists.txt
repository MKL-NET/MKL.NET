cmake_minimum_required (VERSION 3.13)

project ("MKL.NET.Native")

set (CMAKE_BUILD_TYPE "Release")
set (CMAKE_SHARED_LIBRARY_PREFIX "")
add_library (MKL.NET.Native SHARED "MKL.NET.Native.c")
#target_include_directories (MKL.NET.Native PRIVATE ${PROJECT_SOURCE_DIR}/../packages/devel/intelmkl.devel.win-x64/lib/native/include)