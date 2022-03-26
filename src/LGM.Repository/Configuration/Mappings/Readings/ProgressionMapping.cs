using LGM.Domain.Entities.Readings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LGM.Repository.Configuration.Mappings.Readings;
public sealed class ProgressionMapping : IEntityTypeConfiguration<Progression>
{
    public void Configure(EntityTypeBuilder<Progression> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Chapter)
            .IsRequired();

        builder.Property(p => p.PageNumber)
            .IsRequired();

        builder.Property(p => p.Paragraph)
            .IsRequired();

        builder.ToTable("Progressions", "reading");
    }
}

