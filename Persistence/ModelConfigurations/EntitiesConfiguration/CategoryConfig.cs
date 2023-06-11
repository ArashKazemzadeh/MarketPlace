using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistence.ModelConfigurations.EntitiesConfiguration
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__19093A2B7D631E80");

            entity.ToTable("Categories");

            entity.Property(e => e.Name).HasMaxLength(100);


            entity.HasMany(d => d.Products).WithMany(p => p.Categories)
                .UsingEntity<Dictionary<string, object>>(
                    "ProductsCategory",
                    r => r.HasOne<Product>().WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ProductsI__Produ__4316F928"),
                    l => l.HasOne<Category>().WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ProductsI__Categ__4222D4EF"),
                    j =>
                    {
                        j.HasKey("CategoryId", "ProductId").HasName("PK__Products__D249F64504564426");
                        j.ToTable("ProductsCategory");
                    });

               entity.HasData(
                new Category
                {
                    Id = 1,
                    Name = "تکنولوژی",
                    Description = "تجهیزات رایانه ",
                    
                },
                new Category
                {
                Id = 2,
                Name = "هنری",
                Description = "انواع ساز و تابلو های نقاشی",

                },
                new Category
                {
                Id = 3,
                Name = "لوازم منزل",
                Description = "همه ی لوازم مورد نیاز در منزل",

                },
                new Category
                {
                    Id = 4,
                    Name = "سایر",
                    Description = "شامل همه ی کالاهایی که در دسته باندی بالا موجود نیست.",

                });
        }
    }
}
