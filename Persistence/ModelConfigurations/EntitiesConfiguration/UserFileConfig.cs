using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfigurations.EntitiesConfiguration
{
    public class UserFileConfig : IEntityTypeConfiguration<ConsoleApp1.Models.File>
    {
        public void Configure(EntityTypeBuilder<ConsoleApp1.Models.File> entity)
        {
            entity.ToTable("Files");
          
            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Seller).WithMany(p => p.Files)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK_File_Seller");
        }
    }
}
