using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Domain.ValueObjects;
using Xunit;

namespace TimeSheets.Tests.ValueObjectsTests
{
	public class MoneyValueObjectTests
	{
		[Fact]
		public void MoneyValueObject_CreatingFromDecimal()
		{
			//Arrange
			var amount = (decimal)(new Random().NextDouble());

			//Act
			var money = Money.FromDecimal(amount);

			//Assert
			money.Amount.Should().Be(amount);
		}

		[Fact]
		public void MoneyValueObject_DontCreateNegativeAmount()
		{
			//Arrange
			var amount = -1m;

			//Act
			Action act = () => Money.FromDecimal(amount);

			//Assert
			act.Should().Throw<ArgumentException>();
			
		}

	}
}
