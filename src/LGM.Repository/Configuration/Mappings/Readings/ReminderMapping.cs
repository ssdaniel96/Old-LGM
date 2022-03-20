using LGM.Domain.Entities.Readings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LGM.Repository.Configuration.Mappings.Readings;
public sealed class ReminderMapping : IEntityTypeConfiguration<Reminder>
{
    public void Configure(EntityTypeBuilder<Reminder> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.KickOf)
            .WithMany()
            .HasForeignKey("KickOffMemberId")
            .IsRequired();

        builder.HasOne(p => p.Responsible)
            .WithMany()
            .HasForeignKey("ResponsibleMemberId")
            .IsRequired();

        builder.HasOne(p => p.Prayer)
            .WithMany()
            .HasForeignKey("PrayerMemberId")
            .IsRequired();

        builder.Property(p => p.Chapter)
            .IsRequired();

        builder.Property(p => p.PageNumber)
            .IsRequired();

        builder.Property(p => p.Paragraph)
            .IsRequired();

        builder.ToTable("Reminders", "reading");
    }
}

