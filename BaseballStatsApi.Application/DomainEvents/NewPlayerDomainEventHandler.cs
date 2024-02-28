using MediatR;
using Microsoft.Extensions.Logging;

namespace BaseballStatsApi.Application.DomainEvents;

public class NewPlayerDomainEventHandler : INotificationHandler<NewPlayerDomainEvent>
{
    private readonly ILogger<NewPlayerDomainEventHandler> _logger;

    public NewPlayerDomainEventHandler(ILogger<NewPlayerDomainEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(NewPlayerDomainEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Please welcome {Name} to the {Team}", notification.PlayerName, notification.TeamName);
        return Task.CompletedTask;
    }
}