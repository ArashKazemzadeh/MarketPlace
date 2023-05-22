using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrustracture.EntitiesConfiguration
{
    public class ProductsCartConfig : IEntityTypeConfiguration<ProductsCart>
    {
        public void Configure(EntityTypeBuilder<ProductsCart> entity)
        {

            entity.Property(e=>e.ProductId).ValueGeneratedNever();
            entity.Property(e=>e.CartId).ValueGeneratedNever();
            entity.HasKey(e => new { e.CartId, e.ProductId });

            entity.HasOne(d => d.Cart).WithMany(p => p.ProductsCarts)
                .HasForeignKey(d => d.CartId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductsInCart_ShoppingCart");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductsCarts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ProductsCart_Product");
        }
    }
}
