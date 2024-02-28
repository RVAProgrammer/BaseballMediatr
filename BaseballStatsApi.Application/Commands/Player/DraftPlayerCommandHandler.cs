using BaseballStatsApi.Application.DomainEvents;
using BaseballStatsApi.Domain.ValueObjects;
using BaseballStatsApi.Infrastructure;
using BaseballStatsApi.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BaseballStatsApi.Application.Commands.Player;

public class DraftPlayerCommandHandler : IRequestHandler<DraftPlayerCommand, Outcome>
{
    private readonly BaseballContext _dbContext;

    public DraftPlayerCommandHandler(BaseballContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Outcome> Handle(DraftPlayerCommand request, CancellationToken cancellationToken)
    {
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

        var player = new Domain.Player
        {
            Bats = request.Player.Bats,
            Throws = request.Player.Throws,
            FirstName = request.Player.FirstName,
            LastName = request.Player.LastName,
            DateOfBirth = request.Player.DateOfBirth,
            Team = team,
            Position = position,
            EmailAddress = new EmailAddress(request.Player.EmailAddress)
        };

        player.AddDomainEvent(new NewPlayerDomainEvent($"{request.Player.FirstName} {request.Player.LastName}",
            team.Name));

        await _dbContext.AddAsync(player, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new CommonOutcomes.Success<Guid>(player.PlayerId);
    }
}