using System.Net.Http.Headers;
using Common.Application.Common.Models.ServiceResult;
using Common.Domain.Enums;

namespace Common.Application.Common.Interfaces;

public interface IHttpClientHandler
{
    Task<ServiceResult<TResult>> GenericRequestAsync<TRequest, TResult>(
        string apiName,
        Uri url,
        CancellationToken cancellationToken,
        AuthenticationHeaderValue authenticationHeaderValue = default!,
        MethodType method = MethodType.Get,
        TRequest? requestEntity = default,
        bool disableSsl = default!)
            where TRequest : class
            where TResult : class;
}