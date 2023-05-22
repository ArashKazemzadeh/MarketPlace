﻿using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrustracture.EntitiesConfiguration
{
    public class BidConfig : IEntityTypeConfiguration<Bid>
    {
        public void Configure(EntityTypeBuilder<Bid> entity)
        {
            entity.HasOne(d => d.Auction).WithMany(p => p.Bids)
                .HasForeignKey(d => d.AuctionId)
                .HasConstraintName("FK_Bids_Auction");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bids)
                .HasForeignKey(d => d.AuctionId)
                .HasConstraintName("FK_Bids_Buyer1");
        }
    }
}
