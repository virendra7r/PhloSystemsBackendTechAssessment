using Newtonsoft.Json;
using PhloSystemsBackendTechAssessment.Models;

namespace PhloSystemsBackendTechAssessment.ProductRepository
{  
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ApiResponse> GetProductsAsync()
        {
            // Fetch the JSON response from the URL
            var response = await _httpClient.GetStringAsync("https://pastebin.com/raw/JucRNpWs");

            // Deserialize the JSON response into the ApiResponse object
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response);
            return apiResponse;
        }
    }
}
