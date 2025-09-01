using Microsoft.EntityFrameworkCore;

namespace DemoShopApplication.Models
{
    public class DemoShopPieDBContext : DbContext
    {
        public DemoShopPieDBContext(DbContextOptions<DemoShopPieDBContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Pie> Pies { get; set; }
    }
}
