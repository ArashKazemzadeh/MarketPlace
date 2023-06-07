using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfigurations.EntitiesConfiguration
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__B40CC6EDE2FD57A1");

            entity.ToTable("Product");

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Booth).WithMany(p => p.Products)
                .HasForeignKey(d => d.BoothId)
                .HasConstraintName("FK__Product__BoothID__3C69FB99");
            entity.HasData(
                new Product
                {
                    Id = 1,
                    Name = "لپ تاپ",
                    BasePrice = 5000000,
                    IsAuction = false,
                    IsConfirm = null,
                    Availability = 10,
                    Description = "لپ تاپ جدید و بسیار کارآمد",
                    IsActive = true,

                },
                new Product
                {
                    Id = 2,
                    Name = "گوشی هوشمند",
                    BasePrice = 2000000,
                    IsAuction = false,
                    IsConfirm = null,
                    Availability = 5,
                    Description = "گوشی هوشمند با قابلیت‌های فراوان",
                    IsActive = true,

                },

                new Product
                {
                    Id = 20,
                    Name = "کتاب برنامه نویسی",
                    BasePrice = 100000,
                    IsAuction = false,
                    IsConfirm = null,
                    Availability = 50,
                    Description = "بهترین کتاب برای یادگیری برنامه‌نویسی",
                    IsActive = true,

                }
            );
        }
    }
}
