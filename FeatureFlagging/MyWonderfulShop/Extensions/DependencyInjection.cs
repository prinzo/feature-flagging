using MyWonderfulShop.API.Products.Services;

namespace MyWonderfulShop.API.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}