using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZaylandShop.ProductCatalog.Entities;

namespace ZaylandShop.ProductCatalog.Storage.Configurations;

public class ProductColorConfiguration : IEntityTypeConfiguration<ProductColor>
{
    public void Configure(EntityTypeBuilder<ProductColor> builder)
    {
        builder.ToTable("ProductColors")
            .HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.CreatedAt)
            .HasDefaultValueSql("current_timestamp")
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Property(x => x.UpdatedDateTime)
            .HasDefaultValueSql("current_timestamp")
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(255);
        
        builder.Property(p => p.Hex)
            .IsRequired()
            .HasMaxLength(7);
        
        builder.HasMany(o => o.Products)
            .WithOne(i => i.ProductColor)
            .HasForeignKey(i => i.ProductColorId);
    }
}