using System.Text;
using Newtonsoft.Json;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace MyTasksAction.IntegrationTests;

public class IntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly CustomWebApplicationFactory<Program> _factory;

    public IntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _factory = factory;
        _factory.CreateClient();
    }


    [Fact]
    public async Task ShouldShowDashboardTasks()
    {
        // var response = await _client.GetAsync($"/TaskActions");
        //
        // Assert.IsTrue(response.IsSuccessStatusCode);
        // var responseText = await response.Content.ReadAsStringAsync();
        // Assert.AreEqual(true, responseText.Contains("test"));
    }
}