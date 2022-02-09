using Common.Application.Common.Models.ServiceResult;
using MediatR;

namespace Common.Application.Common.Interfaces;

public interface IRequestWrapper : IRequest<ServiceResult>
{
}

public interface IRequestHandlerWrapper<in TRequest> : IRequestHandler<TRequest, ServiceResult>
    where TRequest : IRequestWrapper
{
}

public interface IRequestWrapper<TResponse> : IRequest<ServiceResult<TResponse>>
{
}

public interface IRequestHandlerWrapper<in TRequest, TResponse> : IRequestHandler<TRequest, ServiceResult<TResponse>>
    where TRequest : IRequestWrapper<TResponse>
{
}

public interface IRequestPaginatedWrapper<TResponse> : IRequest<PaginatedServiceResult<TResponse>>
{
}

public interface IRequestPaginatedHandlerWrapper<in TRequest, TResponse> : IRequestHandler<TRequest, PaginatedServiceResult<TResponse>>
    where TRequest : IRequestPaginatedWrapper<TResponse>
{
}