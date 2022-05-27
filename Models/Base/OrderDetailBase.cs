using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChedzaApp.api.Models.Base
{
    public class OrderDetailBase :EntityBase
    {

        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        /*[Required]
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="Product Name")]
        public string? ProductName { get; set; }*/
        public int Quantity { get; set; }
        public string ImageUrl { get; set; } = null!;
        [Required, DataType(DataType.Currency), 
         Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }
        [DataType(DataType.Currency), Display(Name = "Total")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double LineItemTotal { get; set; }
    }
}