#include "common.h"
#include "mkl_dfti.h"

DLLEXPORT MKL_LONG ComputeForwardInplace(const int n, MKL_Complex16 x[])
{
    DFTI_DESCRIPTOR_HANDLE handle;
    MKL_LONG status = DftiCreateDescriptor(&handle, DFTI_DOUBLE, DFTI_COMPLEX, 1, n);
    status = DftiCommitDescriptor(handle);
    status = DftiComputeForward(handle, x);
    status = DftiFreeDescriptor(&handle);
    return status;
}

DLLEXPORT MKL_LONG ComputeForward(const int n, MKL_Complex16 x[], MKL_Complex16 y[])
{
    DFTI_DESCRIPTOR_HANDLE handle;
    MKL_LONG status = DftiCreateDescriptor(&handle, DFTI_DOUBLE, DFTI_COMPLEX, 1, n);
    status = DftiSetValue(handle, DFTI_PLACEMENT, DFTI_NOT_INPLACE);
    status = DftiCommitDescriptor(handle);
    status = DftiComputeForward(handle, x, y);
    status = DftiFreeDescriptor(&handle);
    return status;
}

DLLEXPORT MKL_LONG ComputeForwardReal(const int n, double x[], MKL_Complex16 y[])
{
    DFTI_DESCRIPTOR_HANDLE handle;
    MKL_LONG status = DftiCreateDescriptor(&handle, DFTI_DOUBLE, DFTI_REAL, 1, n);
    status = DftiSetValue(handle, DFTI_PLACEMENT, DFTI_NOT_INPLACE);
    status = DftiCommitDescriptor(handle);
    status = DftiComputeForward(handle, x, y);
    status = DftiFreeDescriptor(&handle);
    return status;
}

DLLEXPORT MKL_LONG ComputeForwardScaleInplace(const int n, MKL_Complex16 x[], double scale)
{
    DFTI_DESCRIPTOR_HANDLE handle;
    MKL_LONG status = DftiCreateDescriptor(&handle, DFTI_DOUBLE, DFTI_COMPLEX, 1, n);
    status = DftiSetValue(handle, DFTI_FORWARD_SCALE, scale);
    status = DftiCommitDescriptor(handle);
    status = DftiComputeForward(handle, x);
    status = DftiFreeDescriptor(&handle);
    return status;
}

DLLEXPORT MKL_LONG ComputeForwardScale(const int n, MKL_Complex16 x[], MKL_Complex16 y[], double scale)
{
    DFTI_DESCRIPTOR_HANDLE handle;
    MKL_LONG status = DftiCreateDescriptor(&handle, DFTI_DOUBLE, DFTI_COMPLEX, 1, n);
    status = DftiSetValue(handle, DFTI_PLACEMENT, DFTI_NOT_INPLACE);
    status = DftiSetValue(handle, DFTI_FORWARD_SCALE, scale);
    status = DftiCommitDescriptor(handle);
    status = DftiComputeForward(handle, x, y);
    status = DftiFreeDescriptor(&handle);
    return status;
}

DLLEXPORT MKL_LONG ComputeForwardScaleReal(const int n, double x[], MKL_Complex16 y[], double scale)
{
    DFTI_DESCRIPTOR_HANDLE handle;
    MKL_LONG status = DftiCreateDescriptor(&handle, DFTI_DOUBLE, DFTI_REAL, 1, n);
    status = DftiSetValue(handle, DFTI_PLACEMENT, DFTI_NOT_INPLACE);
    status = DftiSetValue(handle, DFTI_FORWARD_SCALE, scale);
    status = DftiCommitDescriptor(handle);
    status = DftiComputeForward(handle, x, y);
    status = DftiFreeDescriptor(&handle);
    return status;
}

DLLEXPORT MKL_LONG ComputeBackward(const int n, MKL_Complex16 x[], MKL_Complex16 y[])
{
    DFTI_DESCRIPTOR_HANDLE handle;
    MKL_LONG status = DftiCreateDescriptor(&handle, DFTI_DOUBLE, DFTI_COMPLEX, 1, n);
    status = DftiSetValue(handle, DFTI_PLACEMENT, DFTI_NOT_INPLACE);
    status = DftiCommitDescriptor(handle);
    status = DftiComputeBackward(handle, x, y);
    status = DftiFreeDescriptor(&handle);
    return status;
}

DLLEXPORT MKL_LONG ComputeBackwardInplace(const int n, MKL_Complex16 x[])
{
    DFTI_DESCRIPTOR_HANDLE handle;
    MKL_LONG status = DftiCreateDescriptor(&handle, DFTI_DOUBLE, DFTI_COMPLEX, 1, n);
    status = DftiCommitDescriptor(handle);
    status = DftiComputeBackward(handle, x);
    status = DftiFreeDescriptor(&handle);
    return status;
}

DLLEXPORT MKL_LONG ComputeBackwardScale(const int n, MKL_Complex16 x[], MKL_Complex16 y[], double scale)
{
    DFTI_DESCRIPTOR_HANDLE handle;
    MKL_LONG status = DftiCreateDescriptor(&handle, DFTI_DOUBLE, DFTI_COMPLEX, 1, n);
    status = DftiSetValue(handle, DFTI_BACKWARD_SCALE, scale);
    status = DftiSetValue(handle, DFTI_PLACEMENT, DFTI_NOT_INPLACE);
    status = DftiCommitDescriptor(handle);
    status = DftiComputeBackward(handle, x, y);
    status = DftiFreeDescriptor(&handle);
    return status;
}

DLLEXPORT MKL_LONG ComputeBackwardScaleInplace(const int n, MKL_Complex16 x[], double scale)
{
    DFTI_DESCRIPTOR_HANDLE handle;
    MKL_LONG status = DftiCreateDescriptor(&handle, DFTI_DOUBLE, DFTI_COMPLEX, 1, n);
    status = DftiSetValue(handle, DFTI_BACKWARD_SCALE, scale);
    status = DftiCommitDescriptor(handle);
    status = DftiComputeBackward(handle, x);
    status = DftiFreeDescriptor(&handle);
    return status;
}