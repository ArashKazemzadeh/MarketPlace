using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfigurations.EntitiesConfiguration
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> entity)
        {
            entity.ToTable("Comments");

            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Product).WithMany(p => p.Comments)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Comment_Product").OnDelete(DeleteBehavior.Cascade);

            entity.HasData(
                new Comment
                {
                    Id = 1,
                    Title = "عالی",
                    IsConfirm = null,
                    Description = "این محصول عالی است.",
                    ProductId = 1,
                    CustomertId = 1
                },
                new Comment
                {
                    Id = 2,
                    Title = "بد",
                    IsConfirm = null,
                    Description = "این محصول بد است.",
                    ProductId = 1,
                    CustomertId = 2
                },

                new Comment
                {
                    Id = 20,
                    Title = "خوب",
                    IsConfirm = null,
                    Description = "این محصول خوب است.",
                    ProductId = 2,
                    CustomertId = 2
                }
            );
        }
    }

}
