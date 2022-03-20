using LGM.Domain.Entities.People;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LGM.Repository.Configuration.Mappings.People;
public sealed class MemberMapping : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasColumnType("varchar")
            .HasMaxLength(100)
            .IsRequired();

        builder.HasOne(p => p.Group)
            .WithMany(p => p.Members)
            .HasForeignKey("GroupId")
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.ToTable("Members", "people");
    }
}

