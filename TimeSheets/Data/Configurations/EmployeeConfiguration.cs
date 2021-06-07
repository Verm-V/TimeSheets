using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;
using TimeSheets.Models.Entities;

namespace TimeSheets.Data.Configurations
{
	public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
	{
		[ExcludeFromCodeCoverage]
		public void Configure(EntityTypeBuilder<Employee> builder)
		{
			builder.ToTable("employees");

			builder.Property(x => x.Id)
				.ValueGeneratedNever()
				.HasColumnName("Id");

			builder
				.HasOne(x => x.User)
				.WithOne(u => u.Employee)
				.HasForeignKey<Employee>("UserId");
		}
	}
}