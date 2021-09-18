#include "common.h"
#include "mkl_cblas.h"

DLLEXPORT double test_asum(const int n, double x[])
{
    return cblas_dasum(n, x, 1);
}
