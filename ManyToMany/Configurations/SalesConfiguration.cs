using ManyToMany.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManyToMany.Configurations;

public sealed class SalesConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.Property(s => s.BookCount).IsRequired(true);
        builder.Property(s => s.TotalPrice).IsRequired(true);

        builder.HasCheckConstraint("CK_BookCount", "BookCount > 0");
        builder.HasCheckConstraint("CK_TotalPrice", "TotalPrice > 0");
    }
}