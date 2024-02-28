using BaseballStatsApi.Infrastructure;
using MediatR;

namespace BaseballStatsApi.Application.Queries.Player;

public record GetPlayerRequest(Guid PlayerId) : IRequest<Outcome>
{
}