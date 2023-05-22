using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrustracture.EntitiesConfiguration
{
    public class UserFileConfig : IEntityTypeConfiguration<FileForUser>
    {
        public void Configure(EntityTypeBuilder<FileForUser> entity)
        {
            entity.ToTable("Files");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Seller).WithMany(p => p.Files)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK_File_Seller");
        }
    }
}
