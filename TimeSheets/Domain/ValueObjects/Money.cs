using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Domain.ValueObjects
{
	/// <summary>Money vlaue object </summary>
	public sealed class Money : ValueObject
	{
		public decimal Amount { get; }

		// Запрет на создание пустого объекта через стандартный конструктор
		private Money() { }

		private Money(decimal amount)
		{
			Amount = amount;
		}

		/// <summary>Создание нового объекта</summary>
		/// <param name="amount"></param>
		/// <returns></returns>
		public static Money FromDecimal(decimal amount)
		{
			if (amount < 0)
			{
				throw new ArgumentException("Money amount can't be less than 0.");
			}

			return new Money(amount);
		}
	}
}
