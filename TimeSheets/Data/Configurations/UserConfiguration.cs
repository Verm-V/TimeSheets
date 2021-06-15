using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Models.Entities;

namespace TimeSheets.Data.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<UserAggregate>
	{
		[ExcludeFromCodeCoverage]
		public void Configure(EntityTypeBuilder<UserAggregate> builder)
		{
			builder.ToTable("users");

			builder.Property(x => x.Id)
				.ValueGeneratedNever()
				.HasColumnName("Id");

		}
	}
}