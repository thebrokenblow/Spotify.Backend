using Spotify.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Spotify.Persistence.EntityTypeConfigurations;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(group => group.Id);
        builder.HasIndex(group => group.Id).IsUnique();
        builder.Property(group => group.Title).HasMaxLength(100);
    }
}