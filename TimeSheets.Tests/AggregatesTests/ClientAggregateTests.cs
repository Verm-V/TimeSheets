using FluentAssertions;
using TimeSheets.Domain.Aggregates;
using Xunit;

namespace TimeSheets.Tests.AggregatesTests
{
	public class ClientAggregateTests
	{
		[Fact]
		public void ClientAggregate_CreateRandomFromRequest()
		{
			//Arrange
			var request = AggregatesRequestBuilder.CreateRandomClientCreateRequest();

			//Act
			var client = ClientAggregate.CreateFromRequest(request);

			// Assert
			client.UserId.Should().Be(request.UserId);
			client.IsDeleted.Should().BeFalse();

		}

		[Fact]
		public void ClientAggregate_ShouldBeDeleted()
		{
			//Arrange
			var request = AggregatesRequestBuilder.CreateRandomClientCreateRequest();
			var client = ClientAggregate.CreateFromRequest(request);

			//Act
			client.MarkAsDeleted();

			//Assert
			client.IsDeleted.Should().BeTrue();
		}

	}
}
