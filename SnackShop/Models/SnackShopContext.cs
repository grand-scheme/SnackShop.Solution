using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SnackShop.Models{
	public class SnackShopContext : IdentityDbContext<ApplicationUser>{
		public DbSet<Treat> Treats {get; set;}
		public DbSet<Flavor> Flavors {get; set;}
		public DbSet<TreatFlavor> TreatFlavor {get;set;}
		public SnackShopContext(DbContextOptions options) : base(options) { }
	}
}
