using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfigurations.EntitiesConfiguration;

public class IdentityRoleConfig : IEntityTypeConfiguration<IdentityRole<int>>
{
    public void Configure(EntityTypeBuilder<IdentityRole<int>> entity)
    {
        entity.HasData(
            new IdentityRole<int>
            {
                Id = 1,
                Name = "Customer",
                NormalizedName = "CUSTOMER"
            },
            new IdentityRole<int>
            {
                Id = 2,
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole<int>
            {
                Id = 3,
                Name = "Seller",
                NormalizedName = "SELLER"
            }
        );
    }
}