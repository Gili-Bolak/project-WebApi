using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts(int? minPrice, int? maxPrice, int?[] categoryIds, string? productName);
    }
}