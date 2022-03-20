using LGM.Domain.Entities.Books;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LGM.Repository.Configuration.Mappings.Books;
public sealed class BookMapping : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(p => p.Id);

        builder.Property(p => p.Uri)
            .HasConversion(p => p.ToString(), v => new Uri(v))
            .HasColumnType("varchar")
            .HasMaxLength(200)
            .IsRequired();

        builder.HasOne(p => p.Group)
            .WithMany(p => p.Books)
            .HasForeignKey("GroupId")
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();

        builder.Property(p => p.Author)
            .HasMaxLength(100)
            .HasColumnType("varchar")
            .IsRequired();

        builder.Property(p => p.Title)
            .HasMaxLength(100)
            .HasColumnType("varchar")
            .IsRequired();

        builder.Property(p => p.TotalChapters)
            .IsRequired();

        builder.Property(p => p.TotalPages)
            .IsRequired();

        builder.ToTable("Books", "book");
    }
}

