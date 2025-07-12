using Microsoft.EntityFrameworkCore;
using ProductsApi.Models;
using System.Collections.Generic;

namespace ProductsApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
    }
}
