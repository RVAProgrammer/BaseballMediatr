namespace BaseballStatsApi.Application.Dtos;

public class DraftPlayerDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Bats { get; set; }
    public string Throws { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Guid TeamId { get; set; }
    public Guid PositionId { get; set; }
    public string EmailAddress { get; set; }
}