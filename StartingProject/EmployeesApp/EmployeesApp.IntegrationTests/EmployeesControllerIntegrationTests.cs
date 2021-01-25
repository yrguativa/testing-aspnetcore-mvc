using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace EmployeesApp.IntegrationTests
{
    public class EmployeesControllerIntegrationTests : IClassFixture<TestingWebAppFactory<Startup>>
    {

        private readonly HttpClient _client;
        public EmployeesControllerIntegrationTests(TestingWebAppFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task Index_WhenCalled_ReturnsApplicationForm()
        {
            var response = await _client.GetAsync("/Employees");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Mark", responseString);
            Assert.Contains("Evelin", responseString);
        }
    }
}
