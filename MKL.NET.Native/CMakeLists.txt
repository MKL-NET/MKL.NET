cmake_minimum_required (VERSION 3.10)

project ("MKL.NET.Native")

set (CMAKE_SHARED_LIBRARY_PREFIX "")
set (CMAKE_LIBRARY_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR})

if (CMAKE_BINARY_DIR MATCHES "win-x64$")
    add_library (MKL.NET.Native SHARED "Test.c" "Dfti.c")
    target_include_directories (MKL.NET.Native PRIVATE ${PROJECT_SOURCE_DIR}/../packages/devel/intelmkl.devel.win-x64/lib/native/include)
elseif(CMAKE_BINARY_DIR MATCHES "win-x86$")
    add_library (MKL.NET.Native SHARED "Test.c" "Dfti.c")
    target_include_directories (MKL.NET.Native PRIVATE ${PROJECT_SOURCE_DIR}/../packages/devel/intelmkl.devel.win-x86/lib/native/include)
elseif(CMAKE_BINARY_DIR MATCHES "linux-x64$")
    add_library (MKL.NET.Native SHARED "Test.c")
elseif(CMAKE_BINARY_DIR MATCHES "osx-x64$")
    add_library (MKL.NET.Native SHARED "Test.c")
endif()