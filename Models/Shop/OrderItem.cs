using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChedzaApp.api.Models.Base;

namespace ChedzaApp.api.Models.Shop
{
    public class OrderItem : EntityBase
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="Product Name")]
        public string ProductName { get; set; } = null!;
        public int Quantity { get; set; }
        public string ImageUrl { get; set; } = null!;
        [Required, DataType(DataType.Currency), 
         Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }
        [DataType(DataType.Currency), Display(Name = "Total")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal LineItemTotal { get; set; } 

        #region Navigation Properties(Retrieves One Record)
        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; } = null!;   
        [ForeignKey(nameof(ProductId))]
        public Product Product { get; set; } = null!;
        #endregion
        #region Navigation Properties(Retrieves Many Records)
        //code here..
        #endregion
        

    }
}