using Microsoft.EntityFrameworkCore;

namespace DemoShopAdmin.Service.Data
{
	public class DemoShopAdminContext : DbContext
    {
        public DemoShopAdminContext (DbContextOptions<DemoShopAdminContext> options)
            : base(options)
        {
        }

        public DbSet<DemoShopAdmin.Model.Models.Category> Category { get; set; }

        public DbSet<DemoShopAdmin.Model.Models.Product> Product { get; set; }
    }
}
