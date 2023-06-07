using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfigurations.EntitiesConfiguration;

public class IdentityUserRoleConfig : IEntityTypeConfiguration<IdentityUserRole<int>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<int>> entity)
    {
        entity.HasData(
            new IdentityUserRole<int>
            {
                UserId = 1, //کاربر یک
                RoleId = 1 //customer
            },
            new IdentityUserRole<int>
            {
                UserId = 2, //admin
                RoleId = 2 //admin
            },
            new IdentityUserRole<int>
            {
                UserId = 3, //کاربر دو
                RoleId = 1 //customer
            },
            new IdentityUserRole<int>
            {
                UserId = 4, //کاربر سه
                RoleId = 3 //seller
            },
            new IdentityUserRole<int>
            {
                UserId = 4, //کاربر سه
                RoleId = 1 //seller
            });
    }
}