using ManyToMany.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManyToMany.Configurations;

public sealed class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(b => b.Name).IsRequired(true).HasMaxLength(255);
        builder.Property(b => b.Description).IsRequired(false).HasMaxLength(500);
        builder.Property(b => b.Price).IsRequired(true).HasColumnType("decimal(5,2)");
        builder.Property(b => b.StockCount).IsRequired(true);

        builder.HasCheckConstraint("CK_Price", "Price > 0");
        builder.HasCheckConstraint("CK_StockCount", "StockCount >= 0");
    }
}