#include "common.h"
#include "mkl_vsl.h"

DLLEXPORT MKL_LONG Quantiles(const int rows, const int cols, double data[], int quantiles_n, double quantiles[], double results[])
{
    VSLSSTaskPtr task;
    const int storage = VSL_SS_MATRIX_STORAGE_ROWS;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, 0, 0);
    status = vsldSSEditQuantiles(task, &quantiles_n, quantiles, results, 0, 0);
    status = vsldSSCompute(task, VSL_SS_QUANTS, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    return status;
}
