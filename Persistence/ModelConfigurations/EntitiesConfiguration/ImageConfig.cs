using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfigurations.EntitiesConfiguration
{
    public class ImageConfig : IEntityTypeConfiguration<ImageForProduct>
    {
        public void Configure(EntityTypeBuilder<ImageForProduct> entity)
        {
            entity.ToTable("Image");

            entity.HasOne(d => d.Product).WithMany(p => p.Images)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Image_Product");
        }
    }
}
