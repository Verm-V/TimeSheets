using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Diagnostics.CodeAnalysis;
using TimeSheets.Models.Entities;

namespace TimeSheets.Data.Configurations
{
	public class ClientConfiguration : IEntityTypeConfiguration<Client>
	{
		[ExcludeFromCodeCoverage]
		public void Configure(EntityTypeBuilder<Client> builder)
		{
			builder.ToTable("clients");

			builder.Property(x => x.Id)
				.ValueGeneratedNever()
				.HasColumnName("Id");

			builder
				.HasOne(x => x.User)
				.WithOne(u => u.Client)
				.HasForeignKey<Client>("UserId");

		}
	}
}
