#ifndef _MKLNET_COMMON_H_
#define _MKLNET_COMMON_H_

#ifdef _WIN32
#  define DLLEXPORT __declspec( dllexport )
#else
#  define DLLEXPORT __attribute__((visibility("default")))
#endif

#endif
