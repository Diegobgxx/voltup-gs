using interfaces;
using Microsoft.AspNetCore.Mvc;
using models;
using Moq;
using webapi_swagger.Controllers;

namespace unit.test
{
    public class ChargingStationsControllerTests
    {
        private readonly Mock<IChargingStationBusiness> _chargingStationBusinessMock;
        private readonly ChargingStationsController _controller;

        public ChargingStationsControllerTests()
        {
            _chargingStationBusinessMock = new Mock<IChargingStationBusiness>();
            _controller = new ChargingStationsController(_chargingStationBusinessMock.Object);
        }

        [Fact]
        public async Task GetChargingStations_ReturnsOk_WithChargingStationList()
        {
            // Arrange
            var chargingStations = new List<ChargingStationModel> { new ChargingStationModel { Id = "1", Endereco = "São Paulo" } };
            _chargingStationBusinessMock.Setup(b => b.GetChargingStationsAsync()).ReturnsAsync(chargingStations);

            // Act
            var result = await _controller.GetChargingStationsAsync();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(chargingStations, okResult.Value);
        }

    }
}