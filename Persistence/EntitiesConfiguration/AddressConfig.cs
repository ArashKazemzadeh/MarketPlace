using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrustracture.EntitiesConfiguration
{
    public class AddressConfig : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> entity)
        {
            entity.ToTable("Addresses");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Street).HasMaxLength(50);
            entity.HasOne(d => d.Seller).WithOne(p => p.Address)
                .HasForeignKey<Address>(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull);


          

        }
    }
}
