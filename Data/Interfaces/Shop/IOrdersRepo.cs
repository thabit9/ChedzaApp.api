using ChedzaApp.api.Data.Base;
using ChedzaApp.api.Models.Shop;
using ChedzaApp.api.Models.Shop.ViewModels;

namespace ChedzaApp.api.Data.Interfaces.Shop
{
    public interface IOrderRepo: IRepo<Order>
    {
        IList<Order> GetOrderHistory();
        OrderWithDetailsAndProductInfo GetOneWithDetails(int orderId);
    }
}