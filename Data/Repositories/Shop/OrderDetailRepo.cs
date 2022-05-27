using ChedzaApp.api.Data.Base;
using ChedzaApp.api.Data.EFContext;
using ChedzaApp.api.Data.Interfaces.Shop;
using ChedzaApp.api.Models.Shop;
using ChedzaApp.api.Models.Shop.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChedzaApp.api.Data.Repositories.Shop
{
    public class OrderDetailRepo : RepoBase<OrderItem>, IOrderDetailRepo
    {
        //public ChedzaContext Context { get; }
        public OrderDetailRepo(ChedzaContext context) : base(context)
        {
            //Context = context;
        }

        internal OrderDetailRepo(DbContextOptions<ChedzaContext> options) : base(options)
        {
        }

        public IEnumerable<OrderDetailWithProductInfo> GetOrderDetailsWithProductInfoForOrder(int orderId)
            => _context.OrderDetailWithProductInfos.Where(x => x.OrderId == orderId).OrderBy(x => x.ModelName);
    }
}