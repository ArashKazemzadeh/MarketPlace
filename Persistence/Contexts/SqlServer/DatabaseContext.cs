using System.Linq.Expressions;
using ConsoleApp1.Models;
using Domin.Attributes;
using Domin.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.ModelConfigurations.AplpyConfiguration;

namespace Persistence.Contexts.SqlServer
{
    public class DatabaseContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        #region Tables

        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Auction> Auctions { get; set; }

        public virtual DbSet<Bid> Bids { get; set; }

        public virtual DbSet<Booth> Booths { get; set; }

        public virtual DbSet<Cart> Carts { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<ConsoleApp1.Models.File> Files { get; set; }

        public virtual DbSet<Image> Images { get; set; }

        public virtual DbSet<Medal> Medals { get; set; }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductsCart> ProductsCarts { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region AddShadowProperty

            foreach (var entityType in modelBuilder.Model.GetEntityTypes()) //یافتن تایپ انتیتی به ازای هر انتیتی
            {
                if (entityType.ClrType.GetCustomAttributes(typeof(AuditableAttribute), true).Length > 0)
                {
                    //افزودن شدوپروپرتی
                    modelBuilder.Entity(entityType.Name).Property<DateTime?>("InsertTime");
                    modelBuilder.Entity(entityType.Name).Property<DateTime?>("UpdateTime");
                    modelBuilder.Entity(entityType.Name).Property<DateTime?>("RemoveTime");
                }
            }

            #endregion

            #region AplyConfiguration
            ModelsConfigurations.ApplyEntityConfigurations(modelBuilder);
            #endregion

            base.OnModelCreating(modelBuilder);

        }














        //public override int SaveChanges()
        //{
        //    #region Set the value to the Shadow property

        //    //در جایی که انتیتی ها در حال تغییر وضعیت بودند
        //    var modifiedEntries = ChangeTracker.Entries()
        //        .Where(p => p.State == EntityState.Added ||
        //                    p.State == EntityState.Modified ||
        //                    p.State == EntityState.Deleted);
        //    foreach (var item in modifiedEntries)  //به ازای هر انتیتی که تغییر وضعیت  داده است
        //    {
        //        var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());
        //        var inserted = entityType.FindProperty("InsertTime");
        //        var updated = entityType.FindProperty("UpdateTime");
        //        var removed = entityType.FindProperty("RemoveTime");
        //        if (item.State == EntityState.Added && inserted != null)
        //        {
        //            item.Property("InsertTime").CurrentValue = DateTime.Now;
        //        }
        //        if (item.State == EntityState.Added && inserted != null)
        //        {
        //            item.Property("UpdateTime").CurrentValue = DateTime.Now;
        //        }
        //        if (item.State == EntityState.Added && inserted != null)
        //        {
        //            item.Property("RemoveTime").CurrentValue = DateTime.Now;
        //        }
        //    }

        //    #endregion

        //    return base.SaveChanges();
        //}
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //#region Set the value to the Shadow property

            ////در جایی که انتیتی ها در حال تغییر وضعیت بودند
            //var modifiedEntries = ChangeTracker.Entries()
            //    .Where(p => p.State == EntityState.Added ||
            //                p.State == EntityState.Modified ||
            //                p.State == EntityState.Deleted);
            //foreach (var item in modifiedEntries)  //به ازای هر انتیتی که تغییر وضعیت  داده است
            //{
            //    var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());
            //    var inserted = entityType.FindProperty("InsertTime");
            //    var updated = entityType.FindProperty("UpdateTime");
            //    var removed = entityType.FindProperty("RemoveTime");
            //    if (item.State == EntityState.Added && inserted != null)
            //    {
            //        item.Property("InsertTime").CurrentValue = DateTime.Now;
            //    }
            //    if (item.State == EntityState.Modified && updated != null)
            //    {
            //        item.Property("UpdateTime").CurrentValue = DateTime.Now;
            //    }
            //    if (item.State == EntityState.Deleted && removed != null)
            //    {
            //        item.Property("RemoveTime").CurrentValue = DateTime.Now;
            //    }

            //}

            //#endregion
            //if (cancellationToken == null)
            //{
            //    cancellationToken = new CancellationToken();
            //}

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}


