using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Domain.ValueObjects;
using TimeSheets.Models.Entities;

namespace TimeSheets.Data.Configurations
{
	public class SheetConfiguration : IEntityTypeConfiguration<SheetAggregate>
	{
		public void Configure(EntityTypeBuilder<SheetAggregate> builder)
		{
			builder.ToTable("sheets");

			builder.Property(x => x.Id)
				.ValueGeneratedNever()
				.HasColumnName("Id");

			builder
				.HasOne(sheet => sheet.Invoice)
				.WithMany(invoice => invoice.Sheets)
				.HasForeignKey("InvoiceId");

			builder
				.HasOne(sheet => sheet.Contract)
				.WithMany(contract => contract.Sheets)
				.HasForeignKey("ContractId");

			builder
				.HasOne(sheet => sheet.Service)
				.WithMany(service => service.Sheets)
				.HasForeignKey("ServiceId");

			builder
				.HasOne(sheet => sheet.Employee)
				.WithMany(employee => employee.Sheets)
				.HasForeignKey("EmployeeId");

			//Value Objects
			var converter = new ValueConverter<SpentTime, int>(
				v => v.Amount,
				v => SpentTime.FromInt(v));

			builder.Property(x => x.Amount)
				.HasConversion(converter);

		}
	}
}