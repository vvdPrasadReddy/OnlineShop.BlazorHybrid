using Moq;
using OnlineShop.API.Controllers;
using OnlineShop.API.Services;

namespace OnlineShop.UnitTests
{
    public class ProductControllerTests
    {
        private Mock<IProductService> _productService;

        [SetUp]
        public void Setup()
        {
            _productService = new Mock<IProductService>();
        }

        [Test]
        public void GetCountiesTest()
        {
            // Arrange
            var controller = new ProductsController(_productService.Object);
            _productService.Setup(x => x.GetProducts()).Returns(new List<API.Models.Product>());

            // Act
            var result = controller.GetProducts();

            // Assert
            Assert.That(result, Is.Not.Null);
        }

    }
}
