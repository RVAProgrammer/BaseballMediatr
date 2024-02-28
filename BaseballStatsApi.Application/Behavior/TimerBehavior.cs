using System.Diagnostics;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BaseballStatsApi.Application.Behaviors;

public class TimerBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<TimerBehavior<TRequest, TResponse>> _logger;

    public TimerBehavior(ILogger<TimerBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var watch = new Stopwatch();
        watch.Start();
        var response = await next();
        watch.Stop();
        _logger.LogInformation("Received request  {Name} took {Timer}ms", typeof(TRequest).Name,
            watch.ElapsedMilliseconds);

        return response;
    }
}