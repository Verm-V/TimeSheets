using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;
using TimeSheets.Models.Entities;

namespace TimeSheets.Data.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		[ExcludeFromCodeCoverage]
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.ToTable("users");

			builder.Property(x => x.Id)
				.ValueGeneratedNever()
				.HasColumnName("Id");

		}
	}
}