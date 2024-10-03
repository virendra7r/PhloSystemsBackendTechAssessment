using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PhloSystemsBackendTechAssessment.Models;
using PhloSystemsBackendTechAssessment.ProductRepository;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace PhloSystemsBackendTechAssessment.Controllers
{
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService productService, ILogger<ProductsController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

       
        [HttpGet("Products")]              
        public async Task<IActionResult> GetProducts([FromQuery] decimal? minprice, [FromQuery] decimal? maxprice, [FromQuery] string size, [FromQuery] string highlight)
        {
            try
            {
                var products = await _productService.GetProductsAsync();

                // Logging the response from the mock API
                //_logger.LogInformation("Retrieved products: {@Products}", products);
                //return Ok(products);



                // Filter the products
                //var filteredProducts = products.AsQueryable();
                IEnumerable<Product> filteredProducts = products.Products;


                if (minprice.HasValue)
                {
                    filteredProducts = filteredProducts.Where(p => p.Price >= minprice.Value);
                }

                if (maxprice.HasValue)
                {
                    filteredProducts = filteredProducts.Where(p => p.Price <= maxprice.Value);
                }

                if (!string.IsNullOrEmpty(size))
                {
                    filteredProducts = filteredProducts.Where(p => p.Sizes.Contains(size));
                }

                // Highlight words if the highlight parameter is provided
                if (!string.IsNullOrEmpty(highlight))
                {
                    var highlightedProducts = HighlightWords(filteredProducts.ToList(), highlight);
                    return Ok(highlightedProducts);
                }

                return Ok(filteredProducts.ToList());


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while filtering products.");
                return StatusCode(500, "Internal server error");
            }
        }


        private List<Product> HighlightWords(List<Product> products, string highlight)
        {
            var wordsToHighlight = highlight.Split(',')
                                            .Select(w => w.Trim())
                                            .ToList();

            foreach (var product in products)
            {
                foreach (var word in wordsToHighlight)
                {
                    product.Description = Regex.Replace(product.Description, $@"\b{Regex.Escape(word)}\b", $"<em>{word}</em>", RegexOptions.IgnoreCase);
                }
            }

            return products;
        }
    }
}

