using LGM.Domain.Entities.Readings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LGM.Repository.Configuration.Mappings.Readings;
public sealed class ReadingPlanMapping : IEntityTypeConfiguration<ReadingPlan>
{
    public void Configure(EntityTypeBuilder<ReadingPlan> builder)
    {
        builder.HasKey(p => p.Id);

        builder.HasOne(p => p.Group)
            .WithMany(p => p.ReadingPlans)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey("GroupId")
            .IsRequired();

        builder.HasOne(p => p.Book)
            .WithMany()
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey("BookId")
            .IsRequired();

        builder.HasOne(p => p.Progression)
            .WithOne(p => p.ReadingPlan)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.ToTable("ReadingPlans", "reading");
    }
}

