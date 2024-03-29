﻿cmake_minimum_required (VERSION 3.20)

project ("MKL.NET.Native")

string (REGEX MATCH "win-x64|win-x86|linux-x64|osx-x64" MKLNET_RUNTIME ${CMAKE_BINARY_DIR})
message(STATUS "MKLNET_RUNTIME = ${MKLNET_RUNTIME}")

set (CMAKE_SHARED_LIBRARY_PREFIX "")

if (MKLNET_RUNTIME STREQUAL "win-x64" OR MKLNET_RUNTIME STREQUAL "win-x86")
    add_compile_options(/W4 /WX /MT)
else()
    add_compile_options(-Wall -Wextra -pedantic -Werror)
endif()

add_library (MKL.NET.Native SHARED "vsl.c" "dfti.c")
target_include_directories (MKL.NET.Native PRIVATE "${PROJECT_SOURCE_DIR}/../packages/devel/intelmkl.devel.${MKLNET_RUNTIME}/lib/native/include")
target_link_directories (MKL.NET.Native PRIVATE "${PROJECT_SOURCE_DIR}/../packages/devel/intelmkl.devel.${MKLNET_RUNTIME}/lib/native/${MKLNET_RUNTIME}")

if (MKLNET_RUNTIME STREQUAL "win-x64" OR MKLNET_RUNTIME STREQUAL "win-x86")
    target_link_libraries (MKL.NET.Native mkl_rt)
else()
    if (MKLNET_RUNTIME STREQUAL "linux-x64")
        target_link_options (MKL.NET.Native PRIVATE "LINKER:--no-as-needed")
    endif()
    target_link_libraries (MKL.NET.Native mkl_rt pthread m dl)
endif()