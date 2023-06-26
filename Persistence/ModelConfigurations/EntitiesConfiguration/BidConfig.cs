using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfigurations.EntitiesConfiguration
{
    public class BidConfig : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> entity)
        {
            entity.HasOne(d => d.Auction).WithMany(p => p.Bids)
                .HasForeignKey(d => d.AuctionId);

            entity.HasOne(d => d.Customer).WithMany(p => p.Bids)
                .HasForeignKey(d => d.CustomerId);
        }
    }
}
