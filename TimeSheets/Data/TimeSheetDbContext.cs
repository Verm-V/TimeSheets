﻿using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using TimeSheets.Data.Configurations;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Domain.ValueObjects;
using TimeSheets.Models.Entities;

namespace TimeSheets.Data
{
	/// <summary>Контекст базы данных</summary>
	[ExcludeFromCodeCoverage]
	public class TimeSheetDbContext : DbContext
	{
		public DbSet<Client> Clients { get; set; }
		public DbSet<Contract> Contracts { get; set; }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<InvoiceAggregate> Invoices { get; set; }
		public DbSet<SheetAggregate> Sheets { get; set; }
		public DbSet<User> Users { get; set; }

		public TimeSheetDbContext(DbContextOptions<TimeSheetDbContext> options) : base(options)
		{
		}

		/// <summary>Конфигурация базы данных</summary>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ClientConfiguration());
			modelBuilder.ApplyConfiguration(new ContractConfiguration());
			modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
			modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
			modelBuilder.ApplyConfiguration(new ServiceConfiguration());
			modelBuilder.ApplyConfiguration(new SheetConfiguration());
			modelBuilder.ApplyConfiguration(new UserConfiguration());
		}
	}
}