using BaseballStatsApi.Infrastructure;
using MediatR;

namespace BaseballStatsApi.Application.Commands.Player;

public record CreatePlayerCommand(Dtos.CreatePlayerDto Player): IRequest<Outcome>
{
    
}