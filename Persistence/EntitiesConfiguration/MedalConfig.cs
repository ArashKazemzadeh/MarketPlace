using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrustracture.EntitiesConfiguration
{
    public class MedalConfig : IEntityTypeConfiguration<Medal>
    {
        public void Configure(EntityTypeBuilder<Medal> entity)
        {
            entity.ToTable("Medals");

            entity.Property(e => e.Type).HasMaxLength(50);

            entity.HasOne(d => d.Seller).WithMany(p => p.Medals)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK_Medal_Seller");
        }
    }
}
