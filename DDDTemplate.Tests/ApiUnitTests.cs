using DDDTemplate.Domain;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Net.Http.Json;

namespace DDDTemplate.Tests
{
    public class ApiUnitTests : IClassFixture<IntegrationTestFactory<Program>>
    {
        private readonly HttpClient _client;
        private readonly IntegrationTestFactory<Program> _factory;

        public ApiUnitTests(IntegrationTestFactory<Program> factory)
        {
            _factory = factory;
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task get_all_orders()
        {
            var httpResponseMessage = await _client.GetAsync("api/order");
            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<List<Order>>();
        }
    }
}