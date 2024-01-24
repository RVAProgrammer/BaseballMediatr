using BaseballStatsApi.Infrastructure;
using MediatR;

namespace BaseballStatsApi.Application.Queries.Player;

public record GetAllPlayersRequest : IRequest<Outcome>
{
    
    
}