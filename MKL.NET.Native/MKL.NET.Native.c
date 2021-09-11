#include <stdlib.h>

#ifdef _WIN32
#  define EXPORTIT __declspec( dllexport )
#else
#  define EXPORTIT __attribute__((visibility("default")))
#endif

EXPORTIT void test(int i)
{

}