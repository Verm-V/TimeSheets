using FluentAssertions;
using System;
using TimeSheets.Domain.Aggregates;
using Xunit;

namespace TimeSheets.Tests.AggregatesTests
{
	public class ContractAggregateTests
	{
		[Fact]
		public void ContractAggregate_CreateRandomFromRequest()
		{
			//Arrange
			var request = AggregatesRequestBuilder.CreateRandomContractCreateRequest();

			//Act
			var contract = ContractAggregate.CreateFromRequest(request);

			// Assert
			contract.Title.Should().Be(request.Title);
			contract.DateStart.Should().Be(request.DateStart);
			contract.DateEnd.Should().Be(request.DateEnd);
			contract.Description.Should().Be(request.Description);
			contract.IsDeleted.Should().BeFalse();
		}

		[Fact]
		public void ContractAggregate_UpdateRandomFromRequest()
		{
			//Arrange
			var createRequest = AggregatesRequestBuilder.CreateRandomContractCreateRequest();
			var contract = ContractAggregate.CreateFromRequest(createRequest);
			var updateRequest = AggregatesRequestBuilder.CreateRandomContractUpdateRequest();

			//Act
			Action act = () =>  contract.UpdateFromRequest(updateRequest);

			// Assert
			act.Should().NotThrow();
		}


		[Fact]
		public void ContractAggregate_ShouldBeDeleted()
		{
			//Arrange
			var request = AggregatesRequestBuilder.CreateRandomContractCreateRequest();
			var contract = ContractAggregate.CreateFromRequest(request);

			//Act
			contract.MarkAsDeleted();

			//Assert
			contract.IsDeleted.Should().BeTrue();
		}

	}
}
