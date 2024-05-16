using OnlineShop.API.Data;
using OnlineShop.API.Models;

namespace OnlineShop.API.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
    public class ProductService : IProductService
    {
        private readonly OnlineShopContext _context;

        public ProductService(OnlineShopContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
    }
}
