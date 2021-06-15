using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Models.Entities;

namespace TimeSheets.Data.Configurations
{
	[ExcludeFromCodeCoverage]
	public class ServiceConfiguration : IEntityTypeConfiguration<ServiceAggregate>
	{
		public void Configure(EntityTypeBuilder<ServiceAggregate> builder)
		{
			builder.ToTable("services");

			builder.Property(x => x.Id)
				.ValueGeneratedNever()
				.HasColumnName("Id");
		}
	}
}