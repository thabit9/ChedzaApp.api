using System.ComponentModel.DataAnnotations;
using ChedzaApp.api.Models.Base;

namespace ChedzaApp.api.Models.Shop.ViewModels
{
    public class CartRecordWithProductInfo : ShoppingCartRecordBase 
    {
        public new int Id { get; set; }
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="GTIN Number")]
        public string? GTIN_Number { get; set; }
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="SKU")]
        public string? SKU { get; set; }
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="Product Name")]
        public string? ProductName { get; set; }
        [MaxLength(50)]
        public string? ModelNumber { get; set; }
        [MaxLength(50)]
        public string? ModelName { get; set; }
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
        public double _Current_Price { get; set; }
        public int _Stock_Count { get; set; }
        public int CategoryId { get; set; }
        [Display(Name = "Category")]
        public string? CategoryName { get; set; }
    }
}