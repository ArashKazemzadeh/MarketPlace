using Microsoft.EntityFrameworkCore;
using Persistence.ModelConfigurations.EntitiesConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.ModelConfigurations.AplpyConfiguration
{
    public static class ModelsConfigurations
    {
        public static void ApplyEntityConfigurations
            (ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuctionConfig());
            modelBuilder.ApplyConfiguration(new AddressConfig());
            modelBuilder.ApplyConfiguration(new BidConfig());
            modelBuilder.ApplyConfiguration(new BoothConfig());
            modelBuilder.ApplyConfiguration(new CartConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new CommentConfig());
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new ImageConfig());
   
            modelBuilder.ApplyConfiguration(new ProductsCartConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
     
            modelBuilder.ApplyConfiguration(new SellerConfig());
            modelBuilder.ApplyConfiguration(new UserFileConfig());
            modelBuilder.ApplyConfiguration(new AdminConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new IdentityRoleConfig());
            modelBuilder.ApplyConfiguration(new IdentityUserRoleConfig());
        }
    }
}
