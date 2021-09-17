#include "common.h"
#include "mkl_dfti.h"

DLLEXPORT MKL_LONG ComputeForwardInplace(const MKL_LONG n, MKL_Complex16 x[])
{
    DFTI_DESCRIPTOR_HANDLE handle;
    MKL_LONG status = DftiCreateDescriptor(&handle, DFTI_DOUBLE, DFTI_COMPLEX, 1, n);
    if (0 != status) return status;
    status = DftiCommitDescriptor(handle);
    if (0 != status) return status;
    status = DftiComputeForward(handle, x);
    if (0 != status) return status;
    status = DftiFreeDescriptor(&handle);
    return status;
}

DLLEXPORT MKL_LONG ComputeForward(const MKL_LONG n, MKL_Complex16 x[], MKL_Complex16 y[])
{
    DFTI_DESCRIPTOR_HANDLE handle;
    MKL_LONG status = DftiCreateDescriptor(&handle, DFTI_DOUBLE, DFTI_COMPLEX, 1, n);
    if (0 != status) return status;
    status = DftiSetValue(handle, DFTI_PLACEMENT, DFTI_NOT_INPLACE);
    if (0 != status) return status;
    status = DftiCommitDescriptor(handle);
    if (0 != status) return status;
    status = DftiComputeForward(handle, x, y);
    if (0 != status) return status;
    status = DftiFreeDescriptor(&handle);
    return status;
}

DLLEXPORT MKL_LONG ComputeForwardReal(const MKL_LONG n, double x[], MKL_Complex16 y[])
{
    DFTI_DESCRIPTOR_HANDLE handle;
    MKL_LONG status = DftiCreateDescriptor(&handle, DFTI_DOUBLE, DFTI_REAL, 1, n);
    if (0 != status) return status;
    status = DftiSetValue(handle, DFTI_PLACEMENT, DFTI_NOT_INPLACE);
    if (0 != status) return status;
    status = DftiCommitDescriptor(handle);
    if (0 != status) return status;
    status = DftiComputeForward(handle, x, y);
    if (0 != status) return status;
    status = DftiFreeDescriptor(&handle);
    return status;
}

DLLEXPORT MKL_LONG ComputeBackward(const MKL_LONG n, MKL_Complex16 x[], MKL_Complex16 y[])
{
    DFTI_DESCRIPTOR_HANDLE handle;
    MKL_LONG status = DftiCreateDescriptor(&handle, DFTI_DOUBLE, DFTI_COMPLEX, 1, n);
    if (0 != status) return status;
    status = DftiSetValue(handle, DFTI_BACKWARD_SCALE, 1.0 / n);
    if (0 != status) return status;
    status = DftiSetValue(handle, DFTI_PLACEMENT, DFTI_NOT_INPLACE);
    if (0 != status) return status;
    status = DftiCommitDescriptor(handle);
    if (0 != status) return status;
    status = DftiComputeBackward(handle, x, y);
    if (0 != status) return status;
    status = DftiFreeDescriptor(&handle);
    return status;
}

DLLEXPORT MKL_LONG ComputeBackwardInplace(const MKL_LONG n, MKL_Complex16 x[])
{
    DFTI_DESCRIPTOR_HANDLE handle;
    MKL_LONG status = DftiCreateDescriptor(&handle, DFTI_DOUBLE, DFTI_COMPLEX, 1, n);
    if (0 != status) return status;
    status = DftiSetValue(handle, DFTI_BACKWARD_SCALE, 1.0 / n);
    if (0 != status) return status;
    status = DftiCommitDescriptor(handle);
    if (0 != status) return status;
    status = DftiComputeBackward(handle, x);
    if (0 != status) return status;
    status = DftiFreeDescriptor(&handle);
    return status;
}