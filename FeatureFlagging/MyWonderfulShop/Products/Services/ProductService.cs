using Microsoft.FeatureManagement;

namespace MyWonderfulShop.API.Products.Services;

public class ProductService : IProductService
{
    private readonly IFeatureManager _featureManager;

    public Product(IFeatureManager featureManager)
    {
        _featureManager = featureManager;
    }
    
    public IEnumerable<Product> FindProductsFindProductsAsync()
    {
        
    }
}