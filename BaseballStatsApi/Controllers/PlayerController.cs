using System.Net.Http.Headers;
using BaseballStatsApi.Application.Commands.Player;
using BaseballStatsApi.Application.Dtos;
using BaseballStatsApi.Application.Queries.Player;
using BaseballStatsApi.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BaseballStatsApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private ISender _sender;

    public PlayerController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var response = await _sender.Send(new GetAllPlayersRequest());

        return response switch
        {
            CommonOutcomes.Success<List<Player>> result => Ok(result.Data),
            _ => new StatusCodeResult(500)
        };
    }

    [HttpGet, Route("{playerId:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid playerId)
    {
        var response = await _sender.Send(new GetPlayerRequest(playerId));

        return response switch
        {
            CommonOutcomes.Success<Player> result => Ok(result.Data),
            CommonOutcomes.InvalidData _ => new BadRequestResult(),
            CommonOutcomes.NotFound _ => new NotFoundResult(),
            _ => new StatusCodeResult(500)
        };
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreatePlayerDto player)
    {
        var response = await _sender.Send(new CreatePlayerCommand(player));

        return response switch
        {
            CommonOutcomes.Success<Guid> result => Ok(result.Data),
            CommonOutcomes.InvalidData _ => new BadRequestResult(),
            CommonOutcomes.NotFound _ => new NotFoundResult(),
            _ => new StatusCodeResult(500)
        };
    }
}