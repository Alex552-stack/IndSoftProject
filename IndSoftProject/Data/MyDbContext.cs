using IndSoftProject.Models;
using Microsoft.EntityFrameworkCore;

namespace IndSoftProject.Data
{
	public class MyDbContext : DbContext
	{
		public MyDbContext(DbContextOptions options) : base(options)
		{
		}

        public DbSet<Produs> Products { get; set; }
		public DbSet<Masina> Cars { get; set; }
		public DbSet<Persoana> Persons { get; set; }
    }
}
