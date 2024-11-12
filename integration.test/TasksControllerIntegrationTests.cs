using System.Net.Http.Json;

namespace integration.test
{
    public class TasksControllerIntegrationTests
    {
        private readonly HttpClient _client;

        public TasksControllerIntegrationTests()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7134")
            };
        }

        [Theory]
        [InlineData("/api/tasks/v1/tasks")]
        public async Task GetTasks_ReturnsOk(string url)
        {
            // Act
            var response = await _client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(content);
        }

        [Theory]
        [InlineData("/api/tasks/v2/task")]
        public async Task CreateTask_ReturnsCreated(string url)
        {
            // Arrange
            var task = new { Name = "Integration Test Task" };

            // Act
            var response = await _client.PostAsJsonAsync(url, task);

            // Assert
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            Assert.NotEmpty(content);
        }
    }
}