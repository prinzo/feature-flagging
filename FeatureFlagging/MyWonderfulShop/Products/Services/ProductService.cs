using Microsoft.FeatureManagement;
using MyWonderfulShop.API.Products.Models;
using MyWonderfulShop.API.Shared;

namespace MyWonderfulShop.API.Products.Services;

public class ProductService : IProductService
{
    private readonly IFeatureManager _featureManager;

    public ProductService(IFeatureManager featureManager)
    {
        _featureManager = featureManager;
    }

    public async Task<IEnumerable<Product>> FindProductsAsync()
    {
        var products = GetDummyProductData();

        if (await _featureManager.IsEnabledAsync(Feature.LimitSearchResults)) products = products.Take(5);

        if (!await _featureManager.IsEnabledAsync(Feature.ShowItemsWithLowStock))
            products = products.Where(p => p.Quantity > 5);

        if (await _featureManager.IsEnabledAsync(Feature.ShowLocallyProducedItemsOnly))
            products = products.Where(p => p.IsLocallyProduced);

        return products;
    }

    private IEnumerable<Product> GetDummyProductData()
    {
        return new Product[]
        {
            new Product {Quantity = 10, IsLocallyProduced = true, Name = "A"},
            new Product {Quantity = 5, IsLocallyProduced = false, Name = "Z"},
            new Product {Quantity = 1, IsLocallyProduced = true, Name = "C"},
            new Product {Quantity = 2, IsLocallyProduced = true, Name = "K"},
            new Product {Quantity = 20, IsLocallyProduced = false, Name = "L"},
            new Product {Quantity = 15, IsLocallyProduced = false, Name = "J"},
            new Product {Quantity = 10, IsLocallyProduced = false, Name = "M"}
        };
    }
}