using Moq;
using OnlineShop.API.Controllers;
using OnlineShop.API.Models;
using OnlineShop.API.Services;

namespace OnlineShop.UnitTests
{
    public class UserControllerTests
    {
        private Mock<IUserService> _userService;

        [SetUp]
        public void Setup()
        {
            _userService = new Mock<IUserService>();
        }

        [Test]
        public void GetCountiesTest()
        {
            // Arrange
            _userService.Setup(x => x.GetCounties()).Returns(new List<Country>());
            var controller = new UserController(_userService.Object);

            // Act
            var result = controller.GetCountries();

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void GetStatesTest()
        {
            // Arrange
            _userService.Setup(x => x.GetStates(It.IsAny<int>())).Returns(new List<State>
            {
                new State
                {
                    Id = 1,
                    StateName = "Test"
                }
            });
            var controller = new UserController(_userService.Object);

            // Act
            var result = controller.GetStates(1);

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void RegisterTest()
        {
            // Arrange
            _userService.Setup(x => x.Register(It.IsAny<API.Shared.ViewModels.UserDetails>())).Returns(true);
            var controller = new UserController(_userService.Object);

            // Act
            var result = controller.Register(new API.Shared.ViewModels.UserDetails());

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public void LoginTest()
        {
            // Arrange
            _userService.Setup(x => x.Login(It.IsAny<API.Shared.ViewModels.LoginModel>())).ReturnsAsync(true);
            var contoller = new UserController(_userService.Object);

            //act
            var result = contoller.Login(new API.Shared.ViewModels.LoginModel());

            //assert
            Assert.That(result, Is.Not.Null);
        }
    }
}