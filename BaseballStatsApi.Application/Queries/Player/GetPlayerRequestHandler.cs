using MediatR;

namespace BaseballStatsApi.Application.Queries.Player;

public class GetPlayerRequestHandler
{
    public class Handler :IRequestHandler<GetPlayerRequest>
    {
        public Handler()
        {
                
        }
        public Task Handle(GetPlayerRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}