using ChedzaApp.api.Data.Base;
using ChedzaApp.api.Data.EFContext;
using ChedzaApp.api.Data.Interfaces.Shop;
using ChedzaApp.api.Models.Shop;
using Microsoft.EntityFrameworkCore;

namespace ChedzaApp.api.Data.Repositories.Shop
{
    public class CustomerRepo : RepoBase<Customer>, ICustomerRepo
    {
        public CustomerRepo(ChedzaContext context) : base(context)
        {
            
        }
        internal CustomerRepo(DbContextOptions<ChedzaContext> options) : base(options)
        {

        }
        public override IEnumerable<Customer> GetAll() => base.GetAll(x => x.FullName);
    }
}