using BaseballStatsApi.Infrastructure;
using BaseballStatsApi.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BaseballStatsApi.Application.Commands.Player;

public class CreatePlayerHandler : IRequestHandler<CreatePlayerCommand, Outcome>
{
    private readonly BaseballContext _dbContext;

    public CreatePlayerHandler(BaseballContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Outcome> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        // if (request.Player == null) //TODO: look at check for nulls
        // {
        //     return new CommonOutcomes.InvalidData("player");
        // }

        var team = await _dbContext.Teams.FirstOrDefaultAsync(x => x.TeamId == request.Player.TeamId,
            cancellationToken);
        if (team == null)
        {
            return new CommonOutcomes.InvalidData("team");
        }

        var position =
            await _dbContext.Positions.FirstOrDefaultAsync(x => x.PositionId == request.Player.PositionId,
                cancellationToken);
        if (position == null)
        {
            return new CommonOutcomes.InvalidData("position");
        }

        //TODO: Import automapper
        var player = new Models.Player
        {
            Bats = request.Player.Bats,
            Throws = request.Player.Throws,
            FirstName = request.Player.FirstName,
            LastName = request.Player.LastName,
            DateOfBirth = request.Player.DateOfBirth,
            Team = team,
            Position = position,
            EmailAddress = request.Player.EmailAddress
        };
        await _dbContext.AddAsync(player, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new CommonOutcomes.Success<Guid>(player.PlayerId);
    }
}