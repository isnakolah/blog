namespace Blog.Application.Common.Models.ServiceResult;

public record ServiceResult
{
    public bool Succeeded => Error is null;
    public ServiceError? Error { get; set; }

    public ServiceResult()
    {
    }

    public ServiceResult(ServiceError? error)
    {
        error ??= ServiceError.DefaultError;
        Error = error;
    }

    #region Helper Methods

    public static ServiceResult Failed(ServiceError error)
    {
        return new ServiceResult(error);
    }

    public static ServiceResult<T> Failed<T>(ServiceError error)
    {
        return new ServiceResult<T>(error);
    }

    public static ServiceResult<T> Failed<T>(T data, ServiceError error)
    {
        return new ServiceResult<T>(data, error);
    }

    public static ServiceResult<T> Success<T>(T data)
    {
        return new ServiceResult<T>(data);
    }

    public static ServiceResult Success()
    {
        return new ServiceResult();
    }

    #endregion
}

public record ServiceResult<T> : ServiceResult
{
    
    public ServiceResult()
    {
    }
    
    public ServiceResult(ServiceError error) : base(error)
    {
    }

    public ServiceResult(in T data)
    {
        Data = data;
    }
    
    public ServiceResult(T data, ServiceError error) : base(error)
    {
        Data = data;
    }

    public T? Data { get; }
}