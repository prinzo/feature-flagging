using Microsoft.AspNetCore.Mvc;
using MyWonderfulShop.API.Products.Services;

namespace MyWonderfulShop.API.Products.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await this._productService.FindProductsAsync();
            return this.Ok(products);
        }
    }
}
