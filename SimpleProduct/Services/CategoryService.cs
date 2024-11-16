using SimpleProduct.DbContexts;
using SimpleProduct.Models;
using SimpleProduct.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace SimpleProduct.Services
{
    public class CategoryService : ICategoryService 
    { 
        private readonly SimpleProductsDbContext _dbContext;
        public CategoryService(SimpleProductsDbContext dbContext)
        {
        _dbContext = dbContext;
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            try
            {
                await _dbContext.Categories.AddAsync(category);
                await _dbContext.SaveChangesAsync();
                return category;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            try
            {
                var categories = await _dbContext.Categories.ToListAsync();
                return categories;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            try
            {
                var category = await _dbContext.Categories.Where(c => c.CategoryId == categoryId).FirstOrDefaultAsync();
                return category;
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            try
            {
                var category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
                if (category == null) throw new KeyNotFoundException("Category no encontrada");

                _dbContext.Categories.Remove(category);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Se produjo un error al eliminar la categoría");
            }
        }
    }
}
