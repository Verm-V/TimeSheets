using FluentAssertions;
using System;
using TimeSheets.Domain.Aggregates;
using Xunit;

namespace TimeSheets.Tests.AggregatesTests
{
	public class SheetAggregateTests
	{

		[Fact]
		public void SheetAggregate_CreateRandomFromSheetRequest()
		{
			//Arrange
			var request = AggregatesRequestBuilder.CreateRandomSheetCreateRequest();

			//Act
			var sheet = SheetAggregate.CreateFromSheetRequest(request);

			// Assert
			sheet.Amount.Amount.Should().Be(request.Amount);
			sheet.ContractId.Should().Be(request.ContractId);
			sheet.EmployeeId.Should().Be(request.EmployeeId);
			sheet.ServiceId.Should().Be(request.ServiceId);
			sheet.Date.Should().Be(request.Date);

		}

		[Fact]
		public void SheetAggregate_ShouldBeApproved()
		{
			//Arrange
			var request = AggregatesRequestBuilder.CreateRandomSheetCreateRequest();
			var sheet = SheetAggregate.CreateFromSheetRequest(request);

			//Act
			sheet.ApproveSheet();

			//Assert
			sheet.IsApproved.Should().BeTrue();
			sheet.ApprovedDate.Should().BeCloseTo(DateTime.Now);
		}

		[Fact]
		public void SheetAggregate_ShouldBeDeleted()
		{
			//Arrange
			var request = AggregatesRequestBuilder.CreateRandomSheetCreateRequest();
			var sheet = SheetAggregate.CreateFromSheetRequest(request);

			//Act
			sheet.MarkAsDeleted();

			//Assert
			sheet.IsDeleted.Should().BeTrue();
		}

		//Arrange
		//Act
		//Assert

	}
}
