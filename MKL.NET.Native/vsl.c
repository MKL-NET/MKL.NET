#include "common.h"
#include "mkl_vsl.h"

const int storage = VSL_SS_MATRIX_STORAGE_ROWS;
const int format = VSL_MATRIX_STORAGE_FULL;

DLLEXPORT int Quantiles(const int rows, const int cols, double data[], const int quantiles_n, double quantiles[], double results[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, 0, 0);
    status = vsldSSEditQuantiles(task, &quantiles_n, quantiles, results, 0, 0);
    status = vsldSSCompute(task, VSL_SS_QUANTS, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    return status;
}

DLLEXPORT int Moments(const int rows, const int cols, double data[], double mean[], double mom2c[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, 0, 0);
    status = vsldSSEditMoments(task, mean, mom2c, 0, 0, mom2c, 0, 0);
    status = vsldSSCompute(task, VSL_SS_MEAN | VSL_SS_2C_MOM, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    return status;
}

DLLEXPORT int Covariance(const int rows, const int cols, double data[], double mean[], double cov[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, 0, 0);
    status = vsldSSEditCovCor(task, mean, cov, &format, 0, 0);
    status = vsldSSCompute(task, VSL_SS_COV, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    return status;
}

DLLEXPORT int CovarianceWeighted(const int rows, const int cols, double data[], double weight[], double mean[], double cov[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, weight, 0);
    status = vsldSSEditCovCor(task, mean, cov, &format, 0, 0);
    status = vsldSSCompute(task, VSL_SS_COV, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    return status;
}

DLLEXPORT int Correlation(const int rows, const int cols, double data[], double mean[], double cor[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, 0, 0);
    status = vsldSSEditCovCor(task, mean, 0, 0, cor, &format);
    status = vsldSSCompute(task, VSL_SS_COR, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    return status;
}

DLLEXPORT int CorrelationWeighted(const int rows, const int cols, double data[], double weight[], double mean[], double cor[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, weight, 0);
    status = vsldSSEditCovCor(task, mean, 0, 0, cor, &format);
    status = vsldSSCompute(task, VSL_SS_COR, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    return status;
}
