using BaseballStatsApi.Domain;
using BaseballStatsApi.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseballStatsApi.Infrastructure.Configurations;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.Property(x => x.EmailAddress).HasConversion<string?>(
            x => x.Value,
            value => new EmailAddress(value!)
        );
    }
}