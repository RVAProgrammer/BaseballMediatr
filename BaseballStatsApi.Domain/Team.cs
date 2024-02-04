namespace BaseballStatsApi.Domain;

public class Team
{
    public Guid TeamId { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Manager { get; set; }
    
    public virtual List<Player> Players { get; set; }
}