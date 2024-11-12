using interfaces;
using Microsoft.AspNetCore.Mvc;
using models;
using Moq;
using webapi_swagger.Controllers;

namespace unit.test
{
    public class UsersControllerTests
    {
        private readonly Mock<IUserBusiness> _userBusinessMock;
        private readonly UsersController _controller;

        public UsersControllerTests()
        {
            _userBusinessMock = new Mock<IUserBusiness>();
            _controller = new UsersController(_userBusinessMock.Object);
        }

        [Fact]
        public async Task GetUsers_ReturnsOk_WithUserList()
        {
            // Arrange
            var users = new List<UserModel> { new UserModel { Id = "1", Nome = "User 1" } };
            _userBusinessMock.Setup(b => b.GetUsersAsync()).ReturnsAsync(users);

            // Act
            var result = await _controller.GetUsersAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(users, okResult.Value);
        }

        [Fact]
        public async Task GetUserById_ReturnsOk_WithUser()
        {
            // Arrange
            var user = new UserModel { Id = "1", Nome = "User 1" };
            _userBusinessMock.Setup(b => b.GetUserByIdAsync("1")).ReturnsAsync(user);

            // Act
            var result = await _controller.GetUserByIdAsync("1");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(user, okResult.Value);
        }

        [Fact]
        public async Task GetUserById_ReturnsNotFound_WhenUserDoesNotExist()
        {
            // Arrange
            _userBusinessMock.Setup(b => b.GetUserByIdAsync("1")).ReturnsAsync((UserModel)null);

            // Act
            var result = await _controller.GetUserByIdAsync("1");

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }
        
    }
}