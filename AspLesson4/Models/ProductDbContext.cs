using AspLesson4.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspLesson4.Models
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> opt)
            :base(opt)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
