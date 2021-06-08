using FluentAssertions;
using System;
using TimeSheets.Domain.Aggregates;
using Xunit;

namespace TimeSheets.Tests.AggregatesTests
{
	public class ServiceAggregateTests
	{
		[Fact]
		public void ServiceAggregate_CreateRandomFromRequest()
		{
			//Arrange
			var request = AggregatesRequestBuilder.CreateRandomServiceRequest();

			//Act
			var service = ServiceAggregate.CreateFromRequest(request);

			// Assert
			service.Name.Should().Be(request.Name);
			service.IsDeleted.Should().BeFalse();

		}

		[Fact]
		public void ServiceAggregate_UpdateRandomFromRequest()
		{
			//Arrange
			var createRequest = AggregatesRequestBuilder.CreateRandomServiceRequest();
			var service = ServiceAggregate.CreateFromRequest(createRequest);
			var updateRequest = AggregatesRequestBuilder.CreateRandomServiceRequest();

			//Act
			Action act = () => service.UpdateFromRequest(updateRequest);

			// Assert
			act.Should().NotThrow();
		}



		[Fact]
		public void ServiceAggregate_ShouldBeDeleted()
		{
			//Arrange
			var request = AggregatesRequestBuilder.CreateRandomServiceRequest();
			var service = ServiceAggregate.CreateFromRequest(request);

			//Act
			service.MarkAsDeleted();

			//Assert
			service.IsDeleted.Should().BeTrue();
		}

	}
}
