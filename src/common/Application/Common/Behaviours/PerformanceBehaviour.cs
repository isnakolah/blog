using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Common.Application.Common.Behaviours;

internal sealed class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly Stopwatch _timer;
    private readonly ILogger<TRequest> _logger;

    public PerformanceBehaviour(ILogger<TRequest> logger)
    {
        (_timer, _logger) = (new Stopwatch(), logger);
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();

        var elapsedMilliseconds = _timer.ElapsedMilliseconds;

        if (elapsedMilliseconds > 500)
        {
            _logger.LogWarning("EPharmacy Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}",typeof(TRequest).Name, elapsedMilliseconds, request);
        }

        return response;
    }
}