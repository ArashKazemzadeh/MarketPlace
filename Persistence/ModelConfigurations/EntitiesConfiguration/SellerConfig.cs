
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfigurations.EntitiesConfiguration
{
    public class SellerConfig : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__Seller__7FE3DBA13EC0B8EB");

            entity.ToTable("Sellers");
            entity.HasQueryFilter(e => !e.IsRemoved);
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CompanyName).HasMaxLength(100);
           

        }
    }
}
