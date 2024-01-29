using BaseballStatsApi.Infrastructure;
using BaseballStatsApi.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BaseballStatsApi.Application.Queries.Player;

public class GetPlayerRequestHandler : IRequestHandler<GetPlayerRequest, Outcome>
{
    private readonly BaseballContext _dbContext;

    public GetPlayerRequestHandler(BaseballContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Outcome> Handle(GetPlayerRequest request, CancellationToken cancellationToken)
    {
        if (request.PlayerId == Guid.Empty) return new CommonOutcomes.InvalidData("playerId");

        var player = await _dbContext.Players
            .Include(x => x.Team)
            .Include(x => x.Position)
            .FirstOrDefaultAsync(x => x.PlayerId == request.PlayerId, cancellationToken: cancellationToken);
        if (player == null)
        {
            return new CommonOutcomes.NotFound();
        }

        var playerDto = new Dtos.Player
        {
            Bats = player.Bats,
            Throws = player.Throws,
            FirstName = player.FirstName,
            LastName = player.LastName,
            PlayerId = player.PlayerId,
            PositionName = player.Position.Name,
            TeamName = player.Team.Name,
            DateOfBirth = player.DateOfBirth,
            EmailAddress = player.EmailAddress ?? ""
        };
        return new CommonOutcomes.Success<Dtos.Player>(playerDto);
    }
}