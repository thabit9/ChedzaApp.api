using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ChedzaApp.api.Models.Base
{
    [Owned]
    public class ProductDetail
    {
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="GTIN Number")]
        public string GTIN_Number { get; set; } = null!;
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="SKU")]
        public string SKU { get; set; } = null!;
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="Product Name")]
        public string ProductName { get; set; } = null!;
        [MaxLength(50)]
        public string ModelNumber { get; set; } = null!;
        [MaxLength(50)]
        public string ModelName { get; set; } = null!;
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="Short Description")]
        public string ShortDesc { get; set; } = null!;
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="Long Description")]
        public string LongDesc { get; set; } = null!;
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="Big Image")]
        public string _Big_Image { get; set; } = null!;
        public string _Dimensions { get; set; } = null!;
        public float _Ratings { get; set; }
        /*public double _Current_Price { get; set; }
        public double _Unit_Price { get; set; }
        public int _Stock_Count { get; set; }*/
    }
}