using ExWebComputer.Model;
using Microsoft.EntityFrameworkCore;

namespace ExWebComputer.Data
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options) { }

        public DbSet<ProductType> ProductTypes { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
