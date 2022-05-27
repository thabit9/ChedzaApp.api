using ChedzaApp.api.Models.Base;
using ChedzaApp.api.Models.Shop;
using ChedzaApp.api.Models.Shop.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ChedzaApp.api.Data.EFContext
{
    public class ChedzaContext : DbContext
    {
        public int CustomerId { get; set; }
        public ChedzaContext(DbContextOptions<ChedzaContext> options) : base(options)
        {
            
        }
        #region Shop Context Properties
        [DbFunction("GetOrderTotal", Schema ="Store")]
        public static int GetOrderTotal(int orderId)
        {
            throw new Exception();
        }
        public DbSet<CartRecordWithProductInfo> CartRecordWithProductInfos { get; set; } = null!;
        public DbSet<OrderDetailWithProductInfo> OrderDetailWithProductInfos { get; set; } = null!;

        public DbSet<Categories> Categories { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderItem> OrderDetails { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        #region Product Extra Properties
        public DbSet<ProductDimensions> ProductDimensions { get; set; } = null!;
        public DbSet<ProductFeatures> ProductFeatures { get; set; } = null!;
        public DbSet<ProductSpecification> ProductSpecification { get; set; } = null!;
        public DbSet<ProductImages> ProductImages { get; set; } = null!;
        public DbSet<ProductRatings> ProductRatings { get; set; } = null!;
        public DbSet<StockCount> StockCounts { get; set; } = null!;
        #endregion
        public DbSet<ShoppingCart> ShoppingCartRecords { get; set; } = null!;
        #endregion
        #region BlogPost Context Properties
        //code here...
        #endregion
        #region Testimonials Context Properties
        //code here...
        #endregion
        #region UserAccess Context Properties
        //code here...
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Shop
            modelBuilder.Entity<CartRecordWithProductInfo>().HasNoKey().ToView("CartRecordWithProductInfo", "Store");
            modelBuilder.Entity<OrderDetailWithProductInfo>().HasNoKey().ToView("OrderDetailWithProductInfo", "Store");
            //modelBuilder.Entity<CartRecordWithProductInfo>().HasNoKey().ToView("CartRecordWithProductInfo", "Store");
            //modelBuilder.Entity<OrderDetailWithProductInfo>().HasNoKey().ToView("OrderDetailWithProductInfo", "Store");

            modelBuilder.Entity<Customer>(entity =>
            {
                //entity.HasIndex(e => e.Email).HasName("IX_Customers").IsUnique();
                entity.HasIndex(e => e.Email).HasDatabaseName("IX_Customers").IsUnique();
            });
            modelBuilder.Entity<Order>().HasQueryFilter(x => x.CustomerId == CustomerId);
            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderDate).HasColumnType("datetime").HasDefaultValueSql("getdate()");
                entity.Property(e => e.ShippingDate).HasColumnType("datetime").HasDefaultValueSql("getdate()");
                entity.Property(e => e.OrderTotal).HasColumnType("money")
                    .HasComputedColumnSql("Store.GetOrderTotal([Id])");
            });
            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.UnitPrice).HasColumnType("money");
                entity.Property(e => e.LineItemTotal).HasColumnType("money")
                    .HasComputedColumnSql("[Quantity]*[UnitPrice]");
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e._Unit_Price).HasColumnType("money");
                entity.Property(e => e._Current_Price).HasColumnType("money");
                entity.OwnsOne(o => o.Detail,
                    pd =>
                    {
                        pd.Property(p => p.GTIN_Number).HasColumnName(nameof(ProductDetail.GTIN_Number));
                        pd.Property(p => p.SKU).HasColumnName(nameof(ProductDetail.SKU));
                        pd.Property(p => p.ProductName).HasColumnName(nameof(ProductDetail.ProductName));
                        pd.Property(p => p.ShortDesc).HasColumnName(nameof(ProductDetail.ShortDesc));
                        pd.Property(p => p.LongDesc).HasColumnName(nameof(ProductDetail.LongDesc));
                        pd.Property(p => p._Big_Image).HasColumnName(nameof(ProductDetail._Big_Image));
                        pd.Property(p => p._Dimensions).HasColumnName(nameof(ProductDetail._Dimensions));
                        pd.Property(p => p._Ratings).HasColumnName(nameof(ProductDetail._Ratings)); 
                    });
            });
            modelBuilder.Entity<ShoppingCart>().HasQueryFilter(x => x.CustomerId == CustomerId);
            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                /*entity.HasIndex(e => new { ShoppingCartRecordId = e.Id, e.ProductId, e.CustomerId })
                .HasName("IX_ShoppingCart").IsUnique();*/
                entity.HasIndex(e => new { ShoppingCartRecordId = e.Id, e.ProductId, e.CustomerId })
                .HasDatabaseName("IX_ShoppingCart").IsUnique();
                entity.Property(e => e.DateCreated).HasColumnType("datetime").HasDefaultValueSql("getdate()");
                entity.Property(e => e.Quantity).HasDefaultValue(1);
            });
            #endregion
            #region BlogPost
            //code here...
            #endregion
            #region Testimonials
            //code here...
            #endregion
            #region UserAccess
            //code here...
            #endregion
        }

        
    }
}