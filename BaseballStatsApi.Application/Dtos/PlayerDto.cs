namespace BaseballStatsApi.Application.Dtos;

public class PlayerDto
{
    public Guid PlayerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Bats { get; set; }
    public string Throws { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Guid TeamId { get; set; }
    public string TeamName { get; set; }
    public Guid PositionId { get; set; }
    public string PositionName { get; set; }
    public string EmailAddress { get; set; }
}