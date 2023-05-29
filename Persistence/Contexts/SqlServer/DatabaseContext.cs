using ConsoleApp1.Models;
using Domin.Attributes;
using Domin.Entities.Users;
using Infrustracture.EntitiesConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts.SqlServer
{
    public class DatabaseContext: IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
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

        public virtual DbSet<FileForUser> Files { get; set; }

        public virtual DbSet<ImageForProduct> Images { get; set; }

        public virtual DbSet<Invoice> Invoices { get; set; }

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
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("InsertTime");
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("UpdateTime");
                    modelBuilder.Entity(entityType.Name).Property<DateTime>("RemoveTime");
                    modelBuilder.Entity(entityType.Name).Property<bool>("IsRemove");
                }
            }

            #endregion

            #region AplyConfiguration

            modelBuilder.ApplyConfiguration(new AuctionConfig());
            modelBuilder.ApplyConfiguration(new AddressConfig());
            modelBuilder.ApplyConfiguration(new BidConfig());
            modelBuilder.ApplyConfiguration(new BoothConfig());
            modelBuilder.ApplyConfiguration(new CartConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new CommentConfig());
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new ImageConfig());
            modelBuilder.ApplyConfiguration(new InvoiceConfig());
            modelBuilder.ApplyConfiguration(new ProductsCartConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new InvoiceConfig());
            modelBuilder.ApplyConfiguration(new SellerConfig());
            modelBuilder.ApplyConfiguration(new UserFileConfig());

            #endregion


            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            #region Set the value to the Shadow property

            //در جایی که انتیتی ها در حال تغییر وضعیت بودند
            var modifiedEntries = ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Added ||
                            p.State == EntityState.Modified ||
                            p.State == EntityState.Deleted);
            foreach (var item in modifiedEntries)  //به ازای هر انتیتی که تغییر وضعیت  داده است
            {
                var entityType = item.Context.Model.FindEntityType(item.Entity.GetType());
                var inserted = entityType.FindProperty("InsertTime");
                var updated = entityType.FindProperty("UpdateTime");
                var removed = entityType.FindProperty("RemoveTime");
                var isRemoved = entityType.FindProperty("IsRemove");
                if (item.State == EntityState.Added && inserted != null)
                {
                    item.Property("InsertTime").CurrentValue = DateTime.Now;
                }
                if (item.State == EntityState.Added && inserted != null)
                {
                    item.Property("UpdateTime").CurrentValue = DateTime.Now;
                }
                if (item.State == EntityState.Added && inserted != null)
                {
                    item.Property("RemoveTime").CurrentValue = DateTime.Now;
                    item.Property("IsRemove").CurrentValue = true;
                }
            }

            #endregion

            return base.SaveChanges();
        }
    }
}
