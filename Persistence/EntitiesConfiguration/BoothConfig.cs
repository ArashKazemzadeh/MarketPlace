
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrustracture.EntitiesConfiguration
{
    public class BoothConfig : IEntityTypeConfiguration<Booth>
    {
        public void Configure(EntityTypeBuilder<Booth> entity)
        {
           
                entity.HasKey(e => e.Id).HasName("PK__Booth__E2D0E1DD5CEB9CEA");

                entity.ToTable("Booths");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Seller).WithOne(p => p.Booth)
                .HasForeignKey<Booth>(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
