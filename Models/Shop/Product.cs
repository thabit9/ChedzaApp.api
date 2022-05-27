using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChedzaApp.api.Models.Base;

namespace ChedzaApp.api.Models.Shop
{
    public class Product : EntityBase
    {
        public ProductDetail Detail { get; set; } = new ProductDetail();
        /*[DataType(DataType.Text), MaxLength(256),
         Display(Name ="GTIN Number")]
        public string? GTIN_Number { get; set; }
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="SKU")]
        public string? SKU { get; set; }
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="Product Name")]
        public string? ProductName { get; set; }
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="Short Description")]
        public string? ShortDesc { get; set; }
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="Long Description")]
        public string? LongDesc { get; set; }
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="Big Image")]
        public string? _Big_Image { get; set; }
        public string? _Dimensions { get; set; }
        public float _Ratings { get; set; }
        public double _Unit_Price { get; set; }
        public double _Current_Price { get; set; }
        public int _Stock_Count { get; set; }*/
        public bool IsFeatured { get; set; } 
        [DataType(DataType.Currency)]
        public decimal _Unit_Price { get; set; }
        [DataType(DataType.Currency)]
        public decimal _Current_Price { get; set; }
        public int _Stock_Count { get; set; }
        [Required]
        public int CategoryId { get; set; } 
        #region Navigation Properties(Retrieves One Record)
        [ForeignKey(nameof(CategoryId))]
        public Categories CategoryNavigation { get; set; } = null!;
        #endregion
        #region Navigation Properties(Retrieves Many Records)
        #region Product Extra Properties
        [InverseProperty(nameof(ProductFeatures.Product))] 
        public IEnumerable<ProductFeatures> Features { get; set; } = null!;
        [InverseProperty(nameof(ProductImages.Product))]
        public IEnumerable<ProductImages> Images { get; set; }  = null!;
        [InverseProperty(nameof(ProductSpecification.Product))]
        public IEnumerable<ProductSpecification> Specifications { get; set; } = null!;
        [InverseProperty(nameof(ProductDimensions.Product))]
        public IEnumerable<ProductDimensions> Dimensions { get; set; } = null!;
        [InverseProperty(nameof(StockCount.Product))]
        public IEnumerable<StockCount> StockCounts { get; set; } = null!;
        [InverseProperty(nameof(ProductRatings.Product))]
        public IEnumerable<ProductRatings> Ratings { get; set; } = null!;   
        #endregion
        #region Product Shopping Properties
        [InverseProperty(nameof(ShoppingCart.Product))]
        public List<ShoppingCart> ShoppingCartRecords { get; set; } = new List<ShoppingCart>();
        [InverseProperty(nameof(OrderItem.Product))]
        public List<OrderItem> OrderDetails { get; set; } = new List<OrderItem>();
        #endregion
        #endregion
        [NotMapped]
        public string CategoryNam => CategoryNavigation?.CategoryName!;

    }
}
