using Microsoft.EntityFrameworkCore;
using TimeSheets.Models;

namespace TimeSheets.Data
{
	/// <summary>Контекст базы данных</summary>
	public class TimeSheetDbContext : DbContext
	{
		public DbSet<Client> Clients { get; set; }
		public DbSet<Contract> Contracts { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<Sheet> Sheets { get; set; }
		public DbSet<User> Users { get; set; }

		public TimeSheetDbContext(DbContextOptions<TimeSheetDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Client>().ToTable("Clients");
			modelBuilder.Entity<Contract>().ToTable("Contracts");
			modelBuilder.Entity<Employee>().ToTable("Employees");
			modelBuilder.Entity<Service>().ToTable("Services");
			modelBuilder.Entity<Sheet>().ToTable("Sheets");
			modelBuilder.Entity<User>().ToTable("Users");

			modelBuilder.Entity<Sheet>()
				.HasOne(sheet => sheet.Contract)
				.WithMany(contract => contract.Sheets);
		}
	}
}