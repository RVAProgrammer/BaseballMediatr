using BaseballStatsApi.Application.Dtos;
using BaseballStatsApi.Infrastructure;
using MediatR;

namespace BaseballStatsApi.Application.Commands.Player;

public record DraftPlayerCommand(DraftPlayerDto Player) : IRequest<Outcome>
{
}