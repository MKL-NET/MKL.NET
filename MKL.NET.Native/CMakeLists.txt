cmake_minimum_required (VERSION 3.20)

project ("MKL.NET.Native")

string (REGEX MATCH "win-x64|win-x86|linux-x64|osx-x64" MKLNET_RUNTIME ${CMAKE_BINARY_DIR})
message(STATUS "MKLNET_RUNTIME = ${MKLNET_RUNTIME}")

set (CMAKE_SHARED_LIBRARY_PREFIX "")
set (CMAKE_OPTIMIZE_DEPENDENCIES TRUE)
set (CMAKE_INTERPROCEDURAL_OPTIMIZATION TRUE)

add_library (MKL.NET.Native SHARED "test.c" "dfti.c" "blas.c")
target_include_directories (MKL.NET.Native PRIVATE "${PROJECT_SOURCE_DIR}/../packages/devel/intelmkl.devel.${MKLNET_RUNTIME}/lib/native/include")
target_link_directories (MKL.NET.Native PRIVATE "${PROJECT_SOURCE_DIR}/../packages/devel/intelmkl.devel.${MKLNET_RUNTIME}/lib/native/${MKLNET_RUNTIME}")

if (MKLNET_RUNTIME STREQUAL "win-x64")    
    target_link_libraries (MKL.NET.Native mkl_intel_lp64_dll mkl_intel_thread_dll mkl_core_dll)
    add_compile_options(/Wall /GL)
elseif(MKLNET_RUNTIME STREQUAL "win-x86")
    target_link_libraries (MKL.NET.Native mkl_intel_c_dll mkl_intel_thread_dll mkl_core_dll)
    add_compile_options(/Wall /GL)
else()
    target_link_libraries (MKL.NET.Native mkl_intel_lp64 mkl_intel_thread mkl_core)
    add_compile_options(-Wall -Wextra -pedantic -Werror)
endif()