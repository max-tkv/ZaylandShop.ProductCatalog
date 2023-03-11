using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZaylandShop.ProductCatalog.Entities;

namespace ZaylandShop.ProductCatalog.Storage.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products")
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

        builder.Property(p => p.Price)
            .IsRequired();
            
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(p => p.Description)
            .IsRequired(false)
            .HasMaxLength(350);
        
        builder.HasMany(p => p.Categories)
            .WithMany(c => c.Products)
            .UsingEntity(j => j.ToTable("ProductCategories"));

        builder.HasOne(i => i.Brand)
            .WithMany(o => o.Products)
            .HasForeignKey(i => i.BrandId);
        
        builder.HasOne(i => i.ProductColor)
            .WithMany(o => o.Products)
            .HasForeignKey(i => i.ProductColorId);
        
        builder.HasMany(o => o.Files)
            .WithOne(i => i.Product)
            .HasForeignKey(i => i.ProductId);
    }
}