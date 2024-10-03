using PhloSystemsBackendTechAssessment.ProductRepository;
using RichardSzalay.MockHttp;
namespace PhloSystemsBackendTechAssessmentTestProject
{
    public class ProductServiceTests
    {
        [Fact]
        public async Task GetProductsAsync_ReturnsListOfProducts()
        {
            // Arrange
            var mockHttp = new MockHttpMessageHandler();

            // Set up the mock response
            mockHttp.When("https://pastebin.com/raw/JucRNpWs")
                    .Respond("application/json", "[{ \"Name\": \"Product\", \"Price\": 10, \"Size\": \"medium\", \"Description\": \"A great product\" }]");

            var httpClient = mockHttp.ToHttpClient();
            var productService = new ProductService(httpClient);

            // Act
            var products = await productService.GetProductsAsync();

            // Assert
            Assert.NotEmpty(products.Products);
            Assert.Equal("Product", products.Products[0].Title);
        }
    }
}