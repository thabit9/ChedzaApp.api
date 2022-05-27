namespace ChedzaApp.api.Models.Shop.ViewModels
{
    public class CartWithCustomerInfo
    {
        public Customer? Customer { get; set; } 
        public IList<CartRecordWithProductInfo> CartRecords { get; set; } = new List<CartRecordWithProductInfo>();
    }
}