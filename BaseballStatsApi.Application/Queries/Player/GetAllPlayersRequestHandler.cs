using BaseballStatsApi.Infrastructure;
using BaseballStatsApi.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BaseballStatsApi.Application.Queries.Player;

public class GetAllPlayersRequestHandler : IRequestHandler<GetAllPlayersRequest, Outcome>
{
    private readonly BaseballContext _dbContext;

    public GetAllPlayersRequestHandler(BaseballContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Outcome> Handle(GetAllPlayersRequest request, CancellationToken cancellationToken)
    {
        var players = await _dbContext.Players.Include((x=>x.Team)).Include(x=>x.Position).ToListAsync(cancellationToken);

        return new CommonOutcomes.Success<List<Dtos.Player>>(players.Select(x => new Dtos.Player
        {
            Bats = x.Bats,
            Throws = x.Throws,
            FirstName = x.FirstName,
            LastName = x.LastName,
            PlayerId = x.PlayerId,
            PositionName = x.Position.Name,
            PositionId = x.Position.PositionId,
            TeamName = x.Team.Name,
            TeamId = x.Team.TeamId,
            DateOfBirth = x.DateOfBirth,
            EmailAddress = x.EmailAddress.Value
        }).ToList());
    }
}