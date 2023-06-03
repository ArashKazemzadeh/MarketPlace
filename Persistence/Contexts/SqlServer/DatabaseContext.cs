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
                    modelBuilder.Entity(entityType.Name).Property<DateTime?>("InsertTime");
                    modelBuilder.Entity(entityType.Name).Property<DateTime?>("UpdateTime");
                    modelBuilder.Entity(entityType.Name).Property<DateTime?>("RemoveTime");
            
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
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasData(
                    new Customer
                    {
                        Id = 3,
                    }
                );
            });
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasData(
                    new Customer
                    {
                        Id = 1,
                    },
                    new Customer
                    {
                        Id = 2,
                    }
                );
            });
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasData(
                    new User
                    {
                        Id = 1,
                        FullName = "حسن"
                    },
                    new User
                    {
                        Id = 2,
                        FullName = "جعفرقلی"
                    },
                new User
                    {
                        Id = 3,
                        FullName = "ساسان"
                    }
                );
            });
            modelBuilder.Entity<Seller>(entity =>
            {
                entity.HasData(
                    new Seller()
                    {
                        Id = 1,
                        CompanyName = "شرکت نمونه",
                        IsActive = true,
                        CommissionPercentage = 10.5,
                        CommissionsAmount = 500,
                        SalesAmount = 10000,
                        
                    }
                );
            });
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "لپ تاپ",
                    BasePrice = 5000000,
                    IsAuction = false,
                    IsConfirm = false,
                    Availability = 10,
                    Description = "لپ تاپ جدید و بسیار کارآمد",
                    IsActive = true,
                },
                new Product
                {
                    Id = 2,
                    Name = "گوشی هوشمند",
                    BasePrice = 2000000,
                    IsAuction = false,
                    IsConfirm = false,
                    Availability = 5,
                    Description = "گوشی هوشمند با قابلیت‌های فراوان",
                    IsActive = true,
                },
           
                new Product
                {
                    Id = 20,
                    Name = "کتاب برنامه نویسی",
                    BasePrice = 100000,
                    IsAuction = false,
                    IsConfirm = false,
                    Availability = 50,
                    Description = "بهترین کتاب برای یادگیری برنامه‌نویسی",
                    IsActive = true,
                }
            );

            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    Title = "عالی",
                    IsConfirm = true,
                    Description = "این محصول عالی است.",
                    ProductId = 1
                },
                new Comment
                {
                    Id = 2,
                    Title = "بد",
                    IsConfirm = false,
                    Description = "این محصول بد است.",
                    ProductId = 1
                },
   
                new Comment
                {
                    Id = 20,
                    Title = "خوب",
                    IsConfirm = true,
                    Description = "این محصول خوب است.",
                    ProductId = 2
                }
            );
            modelBuilder.Entity<Booth>().HasData(
                new Booth
                {
                    Id = 1,
                    Name = "غذایی",
                    Description = "فروشگاه غذایی",
                    SellerId = 1
                } 
            );

           

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
                //var isRemoved = entityType.FindProperty("IsRemove");
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
  
                }
            }

            #endregion

            return base.SaveChanges();
        }
    }
}
