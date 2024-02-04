using BaseballStatsApi.Domain.ValueObjects;

namespace BaseballStatsApi.Domain;

public class Player
{
    public Guid PlayerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Bats { get; set; }
    public string Throws { get; set; }
    public DateTime DateOfBirth { get; set; }
    public EmailAddress EmailAddress { get; set; }
    public Team Team { get; set; }

    public Position Position { get; set; }
    
}