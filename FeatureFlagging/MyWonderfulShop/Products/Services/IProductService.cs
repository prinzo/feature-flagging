using MyWonderfulShop.API.Products.Models;

namespace MyWonderfulShop.API.Products.Services
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> FindProductsAsync();
    }
}
