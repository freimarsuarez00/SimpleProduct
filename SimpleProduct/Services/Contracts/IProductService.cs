using SimpleProduct.Models;

namespace SimpleProduct.Services.Contracts
{
    public interface IProductService
    {
        Task<List<Product>> GetProductAsync();
        Task<List<Product>> GetProductByCategoryAsync(int categoryId);
        Task<Product> GetProductByIdAsync(int productId);
        Task<Product> AddProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task DeleteProductAsync(int productId);
    }
}
