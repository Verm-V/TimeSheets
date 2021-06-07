using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Models.Entities;

namespace TimeSheets.Data.Configurations
{
	public class EmployeeConfiguration : IEntityTypeConfiguration<EmployeeAggregate>
	{
		[ExcludeFromCodeCoverage]
		public void Configure(EntityTypeBuilder<EmployeeAggregate> builder)
		{
			builder.ToTable("employees");

			builder.Property(x => x.Id)
				.ValueGeneratedNever()
				.HasColumnName("Id");

			builder
				.HasOne(x => x.User)
				.WithOne(u => u.Employee)
				.HasForeignKey<EmployeeAggregate>("UserId");
		}
	}
}