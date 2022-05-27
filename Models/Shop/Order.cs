using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChedzaApp.api.Models.Base;

namespace ChedzaApp.api.Models.Shop
{
    public class Order : EntityBase
    {
        public int CustomerId { get; set; }
        public int ShippingAddressId { get; set; }
        public int BillingAddressId { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Date Ordered")]
        public DateTime? OrderDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name ="Date Shipped")]
        public DateTime? ShippingDate { get; set; }
        public string DiscountName { get; set; } = null!;
        public double DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        [Display(Name = "Sub Total"), DataType(DataType.Currency)]
        public decimal SubTotal { get; set; }
        [Display(Name = "Order Total"), DataType(DataType.Currency)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal OrderTotal { get; set; }
        public string OrderStatus { get; set; } = null!;
        public string OrderNote { get; set; } = null!;

        #region Navigation Properties(Retrieves One Record)
        [ForeignKey(nameof(CustomerId))]
        public Customer CustomerNavigation { get; set; } = null!;
        [ForeignKey(nameof(ShippingAddressId))]  
        public Address ShippingAddress { get; set; } = null!;  
        [ForeignKey(nameof(BillingAddressId))]
        public Address BillingAddress { get; set; } = null!;
        #endregion
        #region Navigation Properties(Retrieves Many Records)
        [InverseProperty(nameof(OrderItem.Order))] 
        public IEnumerable<OrderItem> OrderItems { get; set; } = null!;
        #endregion

    }
}