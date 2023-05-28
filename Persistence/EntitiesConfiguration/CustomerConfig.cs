using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrustracture.EntitiesConfiguration
{
    public class CustomerConfig : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {

            entity.HasKey(e => e.Id).HasName("PK__Buyer__4B81C1CA60F39982");
            entity.ToTable("Customer");
            entity.Property(e => e.Id).ValueGeneratedNever();
          
        }
    }
}
