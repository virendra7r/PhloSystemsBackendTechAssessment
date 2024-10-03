using PhloSystemsBackendTechAssessment.Models;

namespace PhloSystemsBackendTechAssessment.ProductRepository
{   
    public interface IProductService
    {
        Task<ApiResponse> GetProductsAsync();
    }
}
