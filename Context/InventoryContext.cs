using a2Algo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace a2Algo.Context
{
    public class InventoryContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }

        public DbSet<PurcahseModel> ProductPurchases { get; set; }

        public DbSet<SaleModel> ProductSales { get; set; }

        public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
        {

        }
    }
}
