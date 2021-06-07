using FluentAssertions;
using System;
using System.Collections.Generic;
using TimeSheets.Domain.Aggregates;
using Xunit;

namespace TimeSheets.Tests.AggregatesTests
{
	public class InvoiceAggregateTests
	{
		[Fact]
		public void InvoiceAggregate_CreateFromInvoiceRequest()
		{
			//Arrange
			var request = AggregatesRequestBuilder.CreateRandomInvoiceCreateRequest();

			//Act
			var invoice = InvoiceAggregate.CreateFromInvoiceRequest(request);

			//Assert
			invoice.ContractId.Should().Be(request.ContractId);
			invoice.DateStart.Should().Be(request.DateStart);
			invoice.DateEnd.Should().Be(request.DateEnd);
		}

		[Fact]
		public void InvoiceAggregate_CalculateSomeSum_AfterIncludeSomeSheets()
		{
			//Arrange
			var invoiceRequest = AggregatesRequestBuilder.CreateRandomInvoiceCreateRequest();
			var invoice = InvoiceAggregate.CreateFromInvoiceRequest(invoiceRequest);

			var sheets = new List<SheetAggregate>();
			var sheetsCount = 3;
			for (int i = 0; i < sheetsCount; i++)
			{
				var sheetRequest = AggregatesRequestBuilder.CreateRandomSheetCreateRequest();
				sheets.Add(SheetAggregate.CreateFromSheetRequest(sheetRequest));
			}

			//Act
			invoice.IncludeSheets(sheets);

			//Assert
			invoice.Sum.Amount.Should().BeGreaterThan(0);
			invoice.Sheets.Count.Should().Be(sheetsCount);
		}

		[Fact]
		public void InvoiceAggregate_ShouldBeDeleted()
		{
			//Arrange
			var request = AggregatesRequestBuilder.CreateRandomInvoiceCreateRequest();
			var invoice = InvoiceAggregate.CreateFromInvoiceRequest(request);

			//Act
			invoice.MarkAsDeleted();

			//Assert
			invoice.IsDeleted.Should().BeTrue();
		}

	}
}
