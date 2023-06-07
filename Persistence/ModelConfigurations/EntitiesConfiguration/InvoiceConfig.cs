using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfigurations.EntitiesConfiguration
{
    public class InvoiceConfig : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK__Invoice__D796AAD5A0B9A395");

            entity.ToTable("Invoice");

            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.PaymentStatus).HasMaxLength(50);
            entity.Property(e => e.CartId).HasColumnName("CartID");

            entity.HasOne(d => d.Cart).WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CartId)
                .HasConstraintName("FK__Invoice__Shoppin__4E88ABD4");
        }
    }
}
