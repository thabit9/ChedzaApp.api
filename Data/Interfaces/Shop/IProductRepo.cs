using ChedzaApp.api.Data.Base;
using ChedzaApp.api.Models.Shop;

namespace ChedzaApp.api.Data.Interfaces.Shop
{
    public interface IProductRepo : IRepo<Product>
    {
        IList<Product> Search(string searchString);
        IList<Product> GetProductsForCategory(int id);
        IList<Product> GetFeaturedWithCategoryName();
        Product GetOneWithCategoryName(int id);       
    }
}