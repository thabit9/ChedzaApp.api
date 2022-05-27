using ChedzaApp.api.Data.Base;
using ChedzaApp.api.Data.EFContext;
using ChedzaApp.api.Data.Interfaces.Shop;
using ChedzaApp.api.Models.Shop;
using Microsoft.EntityFrameworkCore;

namespace ChedzaApp.api.Data.Repositories.Shop
{
    public class CategoryRepo : RepoBase<Categories>, ICategoryRepo
    {
        public CategoryRepo(ChedzaContext context) : base(context)
        {
            
        }
        internal CategoryRepo(DbContextOptions<ChedzaContext> options) : base(options)
        {

        }
        public override IEnumerable<Categories> GetAll() => base.GetAll(x => x.CategoryName);
    }
}