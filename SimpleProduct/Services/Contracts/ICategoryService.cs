using SimpleProduct.Models;

namespace SimpleProduct.Services.Contracts
{
    public interface ICategoryService 
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int categoryId);
        Task<Category> AddCategoryAsync(Category category);
        Task DeleteCategoryAsync(int categoryId);

    }
}
