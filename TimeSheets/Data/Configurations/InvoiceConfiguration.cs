using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Diagnostics.CodeAnalysis;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Domain.ValueObjects;
using TimeSheets.Models.Entities;

namespace TimeSheets.Data.Configurations
{
	[ExcludeFromCodeCoverage]
	public class InvoiceConfiguration : IEntityTypeConfiguration<InvoiceAggregate>
	{
		public void Configure(EntityTypeBuilder<InvoiceAggregate> builder)
		{
			builder.ToTable("invoices");

			builder.Property(x => x.Id)
				.ValueGeneratedNever()
				.HasColumnName("Id");

			builder
				.HasOne(invoice => invoice.Contract)
				.WithMany(contract => contract.Invoices)
				.HasForeignKey("ContractId");

			//Value Objects
			var converter = new ValueConverter<Money, decimal>(
				v => v.Amount,
				v => Money.FromDecimal(v));

			builder.Property(x => x.Sum)
				.HasConversion(converter);
		}
	}
}