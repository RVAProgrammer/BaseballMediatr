using MediatR;

namespace BaseballStatsApi.Application.Queries.Player;

public record GetPlayerRequest(int PlayerId): IRequest
{
    
}