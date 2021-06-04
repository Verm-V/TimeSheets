using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Models.Entities;

namespace TimeSheets.Data.Configurations
{
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
		}
	}
}