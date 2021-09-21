#include <stdlib.h>
#include "common.h"
#include "mkl_vsl.h"
#include "mkl_trans.h"

const int storage = VSL_SS_MATRIX_STORAGE_ROWS;
const int format = VSL_MATRIX_STORAGE_FULL;

DLLEXPORT int Mean(const int rows, const int cols, double data[], double mean[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, 0, 0);
    status = vsldSSEditTask(task, VSL_SS_ED_MEAN, mean);
    status = vsldSSCompute(task, VSL_SS_MEAN, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    return status;
}

DLLEXPORT int MeanWeigted(const int rows, const int cols, double data[], double weight[], double mean[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, weight, 0);
    status = vsldSSEditTask(task, VSL_SS_ED_MEAN, mean);
    status = vsldSSCompute(task, VSL_SS_MEAN, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    return status;
}

DLLEXPORT int Median(const int rows, const int cols, double data[], double results[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, 0, 0);
    const int quantiles_n = 1;
    const double quantiles = 0.5;
    status = vsldSSEditQuantiles(task, &quantiles_n, &quantiles, results, 0, 0);
    status = vsldSSCompute(task, VSL_SS_QUANTS, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    return status;
}

DLLEXPORT int MedianWeighted(const int rows, const int cols, double data[], double weight[], double results[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, weight, 0);
    const int quantiles_n = 1;
    const double quantiles = 0.5;
    status = vsldSSEditQuantiles(task, &quantiles_n, &quantiles, results, 0, 0);
    status = vsldSSCompute(task, VSL_SS_QUANTS, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    return status;
}

DLLEXPORT int MomentsRaw2(const int rows, const int cols, double data[], double moments[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, 0, 0);
    status = vsldSSEditMoments(task, moments, moments + cols, 0, 0, 0, 0, 0);
    status = vsldSSCompute(task, VSL_SS_MEAN | VSL_SS_2R_MOM, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    MKL_Dimatcopy('C', 'T', cols, 2, 1.0, moments, cols, 2);
    return status;
}

DLLEXPORT int MomentsRaw2Weigted(const int rows, const int cols, double data[], double weight[], double moments[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, weight, 0);
    status = vsldSSEditMoments(task, moments, moments + cols, 0, 0, 0, 0, 0);
    status = vsldSSCompute(task, VSL_SS_MEAN | VSL_SS_2R_MOM, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    MKL_Dimatcopy('C', 'T', cols, 2, 1.0, moments, cols, 2);
    return status;
}

DLLEXPORT int MomentsCentral2(const int rows, const int cols, double data[], double moments[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, 0, 0);
    status = vsldSSEditMoments(task, moments, moments + cols, 0, 0, moments + cols, 0, 0);
    status = vsldSSCompute(task, VSL_SS_MEAN | VSL_SS_2C_MOM, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    MKL_Dimatcopy('C', 'T', cols, 2, 1.0, moments, cols, 2);
    return status;
}

DLLEXPORT int MomentsCentral2Weighted(const int rows, const int cols, double data[], double weight[], double moments[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, weight, 0);
    status = vsldSSEditMoments(task, moments, moments + cols, 0, 0, moments + cols, 0, 0);
    status = vsldSSCompute(task, VSL_SS_MEAN | VSL_SS_2C_MOM, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    MKL_Dimatcopy('C', 'T', cols, 2, 1.0, moments, cols, 2);
    return status;
}

DLLEXPORT int MomentsRaw3(const int rows, const int cols, double data[], double moments[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, 0, 0);
    status = vsldSSEditMoments(task, moments, moments + cols, moments + cols * 2, 0, 0, 0, 0);
    status = vsldSSCompute(task, VSL_SS_MEAN | VSL_SS_2R_MOM | VSL_SS_3R_MOM, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    MKL_Dimatcopy('C', 'T', cols, 3, 1.0, moments, cols, 3);
    return status;
}

DLLEXPORT int MomentsRaw3Weighted(const int rows, const int cols, double data[], double weight[], double moments[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, weight, 0);
    status = vsldSSEditMoments(task, moments, moments + cols, moments + cols * 2, 0, 0, 0, 0);
    status = vsldSSCompute(task, VSL_SS_MEAN | VSL_SS_2R_MOM | VSL_SS_3R_MOM, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    MKL_Dimatcopy('C', 'T', cols, 3, 1.0, moments, cols, 3);
    return status;
}

DLLEXPORT int MomentsCentral3(const int rows, const int cols, double data[], double moments[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, 0, 0);
    double* mom2r = (double*)malloc(cols * 2 * sizeof(double));
    status = vsldSSEditMoments(task, moments, mom2r, mom2r + cols, 0, moments + cols, moments + cols * 2, 0);
    status = vsldSSCompute(task, VSL_SS_MEAN | VSL_SS_2C_MOM | VSL_SS_3C_MOM, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    free(mom2r);
    MKL_Dimatcopy('C', 'T', cols, 3, 1.0, moments, cols, 3);
    return status;
}

DLLEXPORT int MomentsCentral3Weighted(const int rows, const int cols, double data[], double weight[], double moments[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, weight, 0);
    double* mom2r = (double*)malloc(cols * 2 * sizeof(double));
    status = vsldSSEditMoments(task, moments, mom2r, mom2r + cols, 0, moments + cols, moments + cols * 2, 0);
    status = vsldSSCompute(task, VSL_SS_MEAN | VSL_SS_2C_MOM | VSL_SS_3C_MOM, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    free(mom2r);
    MKL_Dimatcopy('C', 'T', cols, 3, 1.0, moments, cols, 3);
    return status;
}

DLLEXPORT int MomentsStandard3(const int rows, const int cols, double data[], double moments[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, 0, 0);
    double* mom2r = (double*)malloc(cols * 2 * sizeof(double));
    status = vsldSSEditMoments(task, moments, mom2r, mom2r + cols, 0, moments + cols, moments + cols * 2, 0);
    status = vsldSSEditTask(task, VSL_SS_ED_SKEWNESS, moments + cols * 2);
    status = vsldSSCompute(task, VSL_SS_MEAN | VSL_SS_SKEWNESS, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    free(mom2r);
    MKL_Dimatcopy('C', 'T', cols, 3, 1.0, moments, cols, 3);
    return status;
}

DLLEXPORT int MomentsStandard3Weighted(const int rows, const int cols, double data[], double weight[], double moments[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, weight, 0);
    double* mom2r = (double*)malloc(cols * 2 * sizeof(double));
    status = vsldSSEditMoments(task, moments, mom2r, mom2r + cols, 0, moments + cols, moments + cols * 2, 0);
    status = vsldSSEditTask(task, VSL_SS_ED_SKEWNESS, moments + cols * 2);
    status = vsldSSCompute(task, VSL_SS_MEAN | VSL_SS_SKEWNESS, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    free(mom2r);
    MKL_Dimatcopy('C', 'T', cols, 3, 1.0, moments, cols, 3);
    return status;
}

DLLEXPORT int MomentsRaw4(const int rows, const int cols, double data[], double moments[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, 0, 0);
    status = vsldSSEditMoments(task, moments, moments + cols, moments + cols * 2, moments + cols * 3, 0, 0, 0);
    status = vsldSSCompute(task, VSL_SS_MEAN | VSL_SS_2R_MOM | VSL_SS_3R_MOM | VSL_SS_4R_MOM, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    MKL_Dimatcopy('C', 'T', cols, 4, 1.0, moments, cols, 4);
    return status;
}

DLLEXPORT int MomentsRaw4Weighted(const int rows, const int cols, double data[], double weight[], double moments[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, weight, 0);
    status = vsldSSEditMoments(task, moments, moments + cols, moments + cols * 2, moments + cols * 3, 0, 0, 0);
    status = vsldSSCompute(task, VSL_SS_MEAN | VSL_SS_2R_MOM | VSL_SS_3R_MOM | VSL_SS_4R_MOM, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    MKL_Dimatcopy('C', 'T', cols, 4, 1.0, moments, cols, 4);
    return status;
}

DLLEXPORT int MomentsCentral4(const int rows, const int cols, double data[], double moments[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, 0, 0);
    double* mom2r = (double*)malloc(cols * 3 * sizeof(double));
    status = vsldSSEditMoments(task, moments, mom2r, mom2r + cols, mom2r + cols * 2, moments + cols, moments + cols * 2, moments + cols * 3);
    status = vsldSSCompute(task, VSL_SS_MEAN | VSL_SS_2C_MOM | VSL_SS_3C_MOM | VSL_SS_4C_MOM, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    free(mom2r);
    MKL_Dimatcopy('C', 'T', cols, 4, 1.0, moments, cols, 4);
    return status;
}

DLLEXPORT int MomentsCentral4Weighted(const int rows, const int cols, double data[], double weight[], double moments[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, weight, 0);
    double* mom2r = (double*)malloc(cols * 3 * sizeof(double));
    status = vsldSSEditMoments(task, moments, mom2r, mom2r + cols, mom2r + cols * 2, moments + cols, moments + cols * 2, moments + cols * 3);
    status = vsldSSCompute(task, VSL_SS_MEAN | VSL_SS_2C_MOM | VSL_SS_3C_MOM | VSL_SS_4C_MOM, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    free(mom2r);
    MKL_Dimatcopy('C', 'T', cols, 4, 1.0, moments, cols, 4);
    return status;
}

DLLEXPORT int MomentsStandard4(const int rows, const int cols, double data[], double moments[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, 0, 0);
    double* mom2r = (double*)malloc(cols * 3 * sizeof(double));
    status = vsldSSEditMoments(task, moments, mom2r, mom2r + cols, mom2r + cols * 2, moments + cols, moments + cols * 2, moments + cols * 3);
    status = vsldSSEditTask(task, VSL_SS_ED_SKEWNESS, moments + cols * 2);
    status = vsldSSEditTask(task, VSL_SS_ED_KURTOSIS, moments + cols * 3);
    status = vsldSSCompute(task, VSL_SS_MEAN | VSL_SS_SKEWNESS | VSL_SS_KURTOSIS, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    free(mom2r);
    MKL_Dimatcopy('C', 'T', cols, 4, 1.0, moments, cols, 4);
    return status;
}

DLLEXPORT int MomentsStandard4Weighted(const int rows, const int cols, double data[], double weight[], double moments[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, weight, 0);
    double* mom2r = (double*)malloc(cols * 3 * sizeof(double));
    status = vsldSSEditMoments(task, moments, mom2r, mom2r + cols, mom2r + cols * 2, moments + cols, moments + cols * 2, moments + cols * 3);
    status = vsldSSEditTask(task, VSL_SS_ED_SKEWNESS, moments + cols * 2);
    status = vsldSSEditTask(task, VSL_SS_ED_KURTOSIS, moments + cols * 3);
    status = vsldSSCompute(task, VSL_SS_MEAN | VSL_SS_SKEWNESS | VSL_SS_KURTOSIS, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    free(mom2r);
    MKL_Dimatcopy('C', 'T', cols, 4, 1.0, moments, cols, 4);
    return status;
}

DLLEXPORT int Quantiles(const int rows, const int cols, double data[], const int quantiles_n, double quantiles[], double results[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, 0, 0);
    status = vsldSSEditQuantiles(task, &quantiles_n, quantiles, results, 0, 0);
    status = vsldSSCompute(task, VSL_SS_QUANTS, VSL_SS_METHOD_FAST);
    status = vslSSDeleteTask(&task);
    return status;
}

DLLEXPORT int QuantilesWeighted(const int rows, const int cols, double data[], double weight[], const int quantiles_n, double quantiles[], double results[])
{
    VSLSSTaskPtr task;
    int status = vsldSSNewTask(&task, &cols, &rows, &storage, data, weight, 0);
    status = vsldSSEditQuantiles(task, &quantiles_n, quantiles, results, 0, 0);
    status = vsldSSCompute(task, VSL_SS_QUANTS, VSL_SS_METHOD_FAST);
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
