using ChedzaApp.api.Data.Base;
using ChedzaApp.api.Models.Shop;
using ChedzaApp.api.Models.Shop.ViewModels;

namespace ChedzaApp.api.Data.Interfaces.Shop
{
    public interface IShoppingCartRepo: IRepo<ShoppingCart>
    {
        CartRecordWithProductInfo GetShoppingCartRecord(int id);
        IEnumerable<CartRecordWithProductInfo> GetShoppingCartRecords(int customerId);
        CartWithCustomerInfo GetShoppingCartRecordsWithCustomer(int customerId);
        ShoppingCart GetBy(int productId);
        int Update(ShoppingCart entity, Product product, bool persist = true);
        int Add(ShoppingCart entity, Product product, bool persist = true);
        int Purchase(int customerId);
    }    
}