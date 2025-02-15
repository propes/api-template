using ApiTemplate.Endpoints;
using ApiTemplate.IntegrationTests.Fixtures;

namespace ApiTemplate.IntegrationTests.Endpoints;

public class GetProductsTests(CustomWebApplicationFactory factory) : IClassFixture<CustomWebApplicationFactory>
{
    [Fact]
    public async Task GetAllProducts()
    {
        // Arrange
        var client = factory.CreateClient();

        // Act
        var response = await client.GetAsync("api/products");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var responseBody = await response.Content.ReadFromJsonAsync<Product[]>();
        Assert.Equal(5, responseBody!.Length);
    }
}
