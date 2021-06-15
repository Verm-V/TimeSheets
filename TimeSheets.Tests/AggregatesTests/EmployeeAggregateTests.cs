using FluentAssertions;
using TimeSheets.Domain.Aggregates;
using Xunit;

namespace TimeSheets.Tests.AggregatesTests
{
	public class EmployeeAggregateTests
	{
		[Fact]
		public void EmployeeAggregate_CreateRandomFromRequest()
		{
			//Arrange
			var request = AggregatesRequestBuilder.CreateRandomEmployeeCreateRequest();

			//Act
			var employee = EmployeeAggregate.CreateFromRequest(request);

			// Assert
			employee.UserId.Should().Be(request.UserId);
			employee.IsDeleted.Should().BeFalse();

		}

		[Fact]
		public void EmployeeAggregate_ShouldBeDeleted()
		{
			//Arrange
			var request = AggregatesRequestBuilder.CreateRandomEmployeeCreateRequest();
			var employee = EmployeeAggregate.CreateFromRequest(request);

			//Act
			employee.MarkAsDeleted();

			//Assert
			employee.IsDeleted.Should().BeTrue();
		}

	}
}
