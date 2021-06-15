using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Models.Entities;

namespace TimeSheets.Data.Configurations
{
	public class ContractConfiguration : IEntityTypeConfiguration<ContractAggregate>
	{
		[ExcludeFromCodeCoverage]
		public void Configure(EntityTypeBuilder<ContractAggregate> builder)
		{
			builder.ToTable("contracts");

			builder.Property(x => x.Id)
				.ValueGeneratedNever()
				.HasColumnName("Id");
		}
	}
}