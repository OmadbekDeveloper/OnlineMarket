
using OnlineMarket.Models.Other;
using System;

namespace OnlineMarket.Data
{
    public class OnlineMarketDB : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql("Server=localhost; Port=5432; User Id=postgres; Password=gamingpsix7131; Database=OnlineMarket");
        //    base.OnConfiguring(optionsBuilder);
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //AddGroup(modelBuilder);

        //    base.OnModelCreating(modelBuilder);
        //}

        public OnlineMarketDB(DbContextOptions<OnlineMarketDB> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<ShippingInfo> ShippingInfos { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set;}

        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<UserProfileUpdateModel> UserProfiles { get; set; }
        //public DbSet<LoginModel> LoginModels { get; set; }
        //public DbSet<RegisterModel> RegisterModels { get; set; }
    }
}
