
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfigurations.EntitiesConfiguration
{
    public class AuctionConfig : IEntityTypeConfiguration<Auction>
    {
        public void Configure(EntityTypeBuilder<Auction> entity)
        {
            entity.ToTable("Auctions");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.EndDeadTime).HasColumnType("datetime");
            entity.Property(e => e.StartDeadTime).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithOne(p => p.Auction)
                .HasForeignKey<Auction>(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Auction_Product1");
        }
    }
}
