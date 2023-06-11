using Domin.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.ModelConfigurations.EntitiesConfiguration;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> entity)
    {
        entity.HasData(
            new User
            {
                Id = 1,
                FullName = "کاربر یک",
                Email = "userone@gmail.com",
                UserName = "userone@gmail.com",
            },
            new User
            {
                Id = 4,
                FullName = "کاربر چهار",
                Email = "userofour@gmail.com",
                UserName = "userfour@gmail.com"
            },
            new User
            {
                Id = 2,
                FullName = "کاربر دو",
                Email = "userotow@gmail.com",
                UserName = "userotow@gmail.com"
            },
            new User
            {
                Id = 3,
                FullName = "کاربر سه",
                Email = "userothree@gmail.com",
                UserName = "userothree@gmail.com"
            }
        );
    }
}