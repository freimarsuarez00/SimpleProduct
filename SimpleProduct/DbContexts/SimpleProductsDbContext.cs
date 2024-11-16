using Microsoft.EntityFrameworkCore;
using SimpleProduct.Models;

namespace SimpleProduct.DbContexts
{
    public class SimpleProductsDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public SimpleProductsDbContext(DbContextOptions<SimpleProductsDbContext> options) : base(options) { }
    }
}
