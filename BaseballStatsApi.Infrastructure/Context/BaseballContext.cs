using BaseballStatsApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BaseballStatsApi.Infrastructure.Context;

public class BaseballContext :DbContext
{
    public BaseballContext(DbContextOptions<BaseballContext> options) : base(options)
    {
            
    }
    public virtual DbSet<Player> Players { get; set; }
}