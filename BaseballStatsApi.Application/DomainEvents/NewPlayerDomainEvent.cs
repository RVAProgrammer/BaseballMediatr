using MediatR;

namespace BaseballStatsApi.Application.DomainEvents;

public record NewPlayerDomainEvent(string PlayerName, string TeamName) : INotification;