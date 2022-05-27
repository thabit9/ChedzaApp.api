using ChedzaApp.api.Data.Base;
using ChedzaApp.api.Data.EFContext;
using ChedzaApp.api.Data.Interfaces.Shop;
using ChedzaApp.api.Models.Shop;
using Microsoft.EntityFrameworkCore;

namespace ChedzaApp.api.Data.Repositories.Shop
{
    public class ProductRepo : RepoBase<Product>, IProductRepo
    {
        public ProductRepo(ChedzaContext context) : base(context)
        {
            
        }
        internal ProductRepo(DbContextOptions<ChedzaContext> options) : base(options)
        {
            
        }
        public override IEnumerable<Product> GetAll() =>
            base.GetAll(x => x.Detail.ModelName!);
        
        public IList<Product> GetFeaturedWithCategoryName() =>
            Table.Where(p => p.IsFeatured)
                .Include(p => p.CategoryNavigation)
                .Include(i => i.Images)
                .Include(d => d.Dimensions)
                .Include(r => r.Ratings)
                .Include(c => c.StockCounts)
                .OrderBy(x => x.Detail.ModelName)
                .ToList();
        
        public Product GetOneWithCategoryName(int id) =>
            Table.Where(p => p.Id == id).Include(p => p.CategoryNavigation).FirstOrDefault()!;
        
        public IList<Product> GetProductsForCategory(int id) => 
            Table.Where(p => p.CategoryId == id)
                .Include(p => p.CategoryNavigation)
                .OrderBy(x => x.Detail.ModelName).ToList();

        public IList<Product> Search(string searchString) =>
            Table.Where(p => EF.Functions.Like(p.Detail.ShortDesc!, $"%{searchString}%")
                || EF.Functions.Like(p.Detail.ModelName!, $"%{searchString}%")).Include(p => p.CategoryNavigation)
                .OrderBy(x => x.Detail.ModelName).ToList();
    }
}