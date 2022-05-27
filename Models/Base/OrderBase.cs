using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChedzaApp.api.Models.Base
{
    public class OrderBase : EntityBase
    {
        /*public int ShippingAddressId { get; set; }
        public int BillingAddressId { get; set; }*/
        [DataType(DataType.Date)]
        [Display(Name ="Date Ordered")]
        public DateTime? OrderDate { get; set; }
        public string DiscountName { get; set; } = null!;
        public int DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        [Display(Name = "Sub Total"), DataType(DataType.Currency)]
        public decimal SubTotal { get; set; }
        [DataType(DataType.Currency), Display(Name = "Total")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal OrderTotal { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Date Shipped")]
        public DateTime? ShippingDate { get; set; }
        public string OrderStatus { get; set; } = null!;
        public string OrderNote { get; set; } = null!;
        [Display(Name ="Customer")]
        public int CustomerId { get; set; }

        //public IList<OrderDetailWithProductInfo>? OrderDetails { get; set; }  

    }
}