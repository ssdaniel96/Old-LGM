using LGM.Domain.Entities.Groups;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LGM.Repository.Configuration.Mappings.Groups;
public sealed class SourceTypeMapping : IEntityTypeConfiguration<SourceType>
{
    public void Configure(EntityTypeBuilder<SourceType> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Description)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.HasData(new List<SourceType>() {
            new("Telegram"),
            new("Discord")
        });

        builder.HasMany<Group>()
            .WithOne()
            .HasForeignKey(p => p.GroupIdentity.SourceTypeEnum)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.ToTable("SourceTypes", "group");
    }
}

