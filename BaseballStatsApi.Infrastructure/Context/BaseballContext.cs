using Microsoft.EntityFrameworkCore;
using BaseballStatsApi.Domain;
using MediatR;

namespace BaseballStatsApi.Infrastructure.Context;

public class BaseballContext : DbContext
{
    private readonly IMediator _mediator;

    public BaseballContext(DbContextOptions<BaseballContext> options, IMediator mediator) : base(options)
    {
        _mediator = mediator;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly((typeof(BaseballContext).Assembly));
    }

    public new async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var domainEntities = ChangeTracker.Entries<Entity>()
            .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

        var domainEvents = domainEntities.SelectMany(x => x.Entity.DomainEvents).ToList();
        domainEntities.ToList().ForEach(x => x.Entity.ClearDomainEvents());
        foreach (var e in domainEvents)
        {
            await _mediator.Publish(e, cancellationToken);
        }


        return await base.SaveChangesAsync(cancellationToken);
    }

    public virtual DbSet<Player> Players { get; set; }
    public virtual DbSet<Team> Teams { get; set; }
    public virtual DbSet<Position> Positions { get; set; }
}