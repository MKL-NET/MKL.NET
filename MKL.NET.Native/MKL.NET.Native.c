#include <stdlib.h>

#ifdef _WIN32
#  define EXPORTIT __declspec( dllexport )
#else
#  define EXPORTIT __attribute__((visibility("default")))
#endif

EXPORTIT int test(int i)
{
    return i;
}