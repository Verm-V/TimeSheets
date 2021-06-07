using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;
using TimeSheets.Models.Entities;

namespace TimeSheets.Data.Configurations
{
	public class ContractConfiguration : IEntityTypeConfiguration<Contract>
	{
		[ExcludeFromCodeCoverage]
		public void Configure(EntityTypeBuilder<Contract> builder)
		{
			builder.ToTable("contracts");

			builder.Property(x => x.Id)
				.ValueGeneratedNever()
				.HasColumnName("Id");
		}
	}
}