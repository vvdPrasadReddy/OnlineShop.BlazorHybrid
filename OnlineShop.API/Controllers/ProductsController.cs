using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.API.Services;

namespace OnlineShop.API.Controllers
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

        [Authorize]
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productService.GetProducts());
        }
    }
}
