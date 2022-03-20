using LGM.Domain.Entities.Groups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LGM.Repository.Configuration.Mappings.Groups;
public sealed class GroupMapping : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.HasKey(p => p.Id);

        builder.OwnsOne(p => p.GroupIdentity)
            .Property(p => p.SourceId)
            .IsRequired();

        builder.OwnsOne(p => p.GroupIdentity)
            .Property(p => p.SourceTypeEnum)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.ToTable("Groups", "group");
    }
}

