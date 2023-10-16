namespace BaseballStatsApi.Models;

public class Team
{
    public int TeamId { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public string Manager { get; set; }
    
    public virtual List<Player> Players { get; set; }
}