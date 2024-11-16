using Microsoft.EntityFrameworkCore;
using SimpleProduct.DbContexts;
using SimpleProduct.Models;
using SimpleProduct.Services.Contracts;

namespace SimpleProduct.Services
{
    public class ProductService : IProductService
    {
        private readonly SimpleProductsDbContext _dbContext;
        public ProductService(SimpleProductsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Product> AddProductAsync(Product product)
        {
            try
            {
                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();
                return product;
            }
            catch
            {
                throw;
            }
        }

        public async Task DeleteProductAsync(int productId)
        {
            try
            {
                var product = await GetProductByIdAsync(productId);
                if (product != null)
                {
                    _dbContext.Products.Remove(product);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Product>> GetProductAsync()
        {
            try
            {
                var products = await _dbContext.Products.ToListAsync();
                return products;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Product>> GetProductByCategoryAsync(int categoryId)
        {
            try
            {
                var products = await _dbContext.Products.Where(p => p.CategoryId == categoryId).ToListAsync();
                return products;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            try
            {
                var product = await _dbContext.Products.Where(p => p.ProductId == productId).FirstOrDefaultAsync();
                return product;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            try
            {
                if (product.ProductId > 0)
                {
                    _dbContext.Entry(product).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                    return product;
                }
                throw new Exception("El producto no se encuentra");
            }
            catch
            {
                throw;
            }
        }
    }
}
