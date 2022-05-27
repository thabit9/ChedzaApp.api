using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ChedzaApp.api.Data.Base;
using ChedzaApp.api.Data.EFContext;
using ChedzaApp.api.Data.Interfaces.Shop;
using ChedzaApp.api.Models.Shop;
using ChedzaApp.api.Models.Shop.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ChedzaApp.api.Data.Repositories.Shop
{
    public class OrderRepo : RepoBase<Order>, IOrderRepo
    {
        private readonly IOrderDetailRepo _orderDetailRepo;

        public OrderRepo(ChedzaContext context, IOrderDetailRepo orderDetailRepo) :
            base(context)
        {
            _orderDetailRepo = orderDetailRepo; 
        }
        internal OrderRepo(DbContextOptions<ChedzaContext> options) : base(options)
        {
            _orderDetailRepo = new OrderDetailRepo(_context);
        }
        public override void Dispose()
        {
            //_orderDetailRepo.Dispose();
            _orderDetailRepo._context.Dispose();
            base.Dispose();
        }
        public IList<Order> GetOrderHistory() =>
            GetAll(x => x.OrderDate!).ToList();
        
        public OrderWithDetailsAndProductInfo GetOneWithDetails(int orderId)
        {
            var order = Table.IgnoreQueryFilters().Include(x => x.CustomerNavigation)
                .FirstOrDefault(x => x.Id == orderId);
            if(order == null)
            {
                return null!;
            }

            var orderDetailsWithProductInfoForOrder = _orderDetailRepo.GetOrderDetailsWithProductInfoForOrder(order.Id);
            var orderWithDetailsAndProductInfo = OrderWithDetailsAndProductInfo.Create(order, order.CustomerNavigation!, orderDetailsWithProductInfoForOrder);
            return orderWithDetailsAndProductInfo;
            
        }
    }
}