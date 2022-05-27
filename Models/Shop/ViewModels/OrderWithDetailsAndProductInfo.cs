using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using ChedzaApp.api.Models.Base;

namespace ChedzaApp.api.Models.Shop.ViewModels
{
    public class OrderWithDetailsAndProductInfo : OrderBase
    {
        private static readonly MapperConfiguration _mapperCfg;
        public Customer? Customer { get; set; }
        public IList<OrderDetailWithProductInfo>? OrderDetails { get; set; }
        static OrderWithDetailsAndProductInfo()
        {
            _mapperCfg = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<OrderDetailWithProductInfo, OrderWithDetailsAndProductInfo>()
                    .ForMember(record => record.OrderDetails, y => y.Ignore());
            });
        }
        public static OrderWithDetailsAndProductInfo Create(Order order, Customer customer, IEnumerable<OrderDetailWithProductInfo> details)
        {
            var viewModel =_mapperCfg.CreateMapper().Map<OrderWithDetailsAndProductInfo>(order);
            viewModel.OrderDetails = details.ToList();
            viewModel.Customer = customer;
            return viewModel;
        
        }
    }
}