using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ChedzaApp.api.Models.Base;

namespace ChedzaApp.api.Models.Shop
{
    public class Address : EntityBase
    {
        public int CustomerId { get; set; }
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="First Name")]
        public string FirstName { get; set; } = null!;
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="Last Name")]
        public string LastName { get; set; } = null!;
        #region  Address Fields
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="Street")]
        public string Street { get; set; } = null!;
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="Street (Optional)")]
        public string Street2 { get; set; } = null!;
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="City")]
        public string City { get; set; } = null!;
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="State")]
        public string State { get; set; } = null!;
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="Country")]
        public string Country { get; set; } = null!;
        [DataType(DataType.Text), MaxLength(256),
         Display(Name ="Zip Code")]
        public string Zip { get; set; } = null!;
        #endregion
        #region Navigation Properties(Retrieves One Record)
        [ForeignKey(nameof(CustomerId))]
        public Customer CustomerAddress { get; set; } = null!;
        #endregion
        #region Navigation Properties(Retrieves Many Record)
        [InverseProperty(nameof(Order.ShippingAddress))]
        public ICollection<Order> ShippingAddresses { get; set; } = null!; 
        [InverseProperty(nameof(Order.BillingAddress))]
        public ICollection<Order> BillingAddresses { get; set; } = null!;  
        #endregion
    }
}