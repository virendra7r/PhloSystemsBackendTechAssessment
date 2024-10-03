using Newtonsoft.Json;
using PhloSystemsBackendTechAssessment.Models;

namespace PhloSystemsBackendTechAssessment.ProductRepository
{  
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public ProductService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        /// <summary>
        /// Asynchronously fetches and deserializes a list of products from a remote API.
        /// </summary>
        /// <returns>An <see cref="ApiResponse"/> containing the product list.</returns>
        /// <author>Virendra Prasad</author>
        /// <date>2024-10-03</date>
        public async Task<ApiResponse> GetProductsAsync()
        {           
            // Fetch the URL from app settings
            string apiUrl = _configuration["ApiSettings:ProductApiUrl"];
            var response = await _httpClient.GetStringAsync(apiUrl);

            // Deserialize the JSON response into the ApiResponse object
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response);
            return apiResponse;
        }
    }
}
