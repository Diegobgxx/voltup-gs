using interfaces;
using Microsoft.AspNetCore.Mvc;
using models;
using Moq;
using webapi_swagger.Controllers;

namespace unit.test
{
    public class VehiclesControllerTests
    {
        private readonly Mock<IVehicleBusiness> _vehicleBusinessMock;
        private readonly VehiclesController _controller;

        public VehiclesControllerTests()
        {
            _vehicleBusinessMock = new Mock<IVehicleBusiness>();
            _controller = new VehiclesController(_vehicleBusinessMock.Object);
        }

        [Fact]
        public async Task GetVehicles_ReturnsOk_WithVehicleList()
        {
            // Arrange
            var vehicles = new List<VehicleModel> { new VehicleModel { Id = "1", Marca = "Model X" } };
            _vehicleBusinessMock.Setup(b => b.GetVehiclesAsync()).ReturnsAsync(vehicles);

            // Act
            var result = await _controller.GetVehiclesAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(vehicles, okResult.Value);
        }

        [Fact]
        public async Task GetVehicleById_ReturnsOk_WithVehicle()
        {
            // Arrange
            var vehicle = new VehicleModel { Id = "1", Marca = "Model X" };
            _vehicleBusinessMock.Setup(b => b.GetVehicleByIdAsync("1")).ReturnsAsync(vehicle);

            // Act
            var result = await _controller.GetVehicleByIdAsync("1");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(vehicle, okResult.Value);
        }

        [Fact]
        public async Task GetVehicleById_ReturnsNotFound_WhenVehicleDoesNotExist()
        {
            // Arrange
            _vehicleBusinessMock.Setup(b => b.GetVehicleByIdAsync("1")).ReturnsAsync((VehicleModel)null);

            // Act
            var result = await _controller.GetVehicleByIdAsync("1");

            // Assert
            var notFoundResult = Assert.IsType<NotFoundResult>(result);
            Assert.Equal(404, notFoundResult.StatusCode);
        }
    }
}