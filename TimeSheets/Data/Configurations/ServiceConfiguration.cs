using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;
using TimeSheets.Models.Entities;

namespace TimeSheets.Data.Configurations
{
	[ExcludeFromCodeCoverage]
	public class ServiceConfiguration : IEntityTypeConfiguration<Service>
	{
		public void Configure(EntityTypeBuilder<Service> builder)
		{
			builder.ToTable("services");

			builder.Property(x => x.Id)
				.ValueGeneratedNever()
				.HasColumnName("Id");
		}
	}
}