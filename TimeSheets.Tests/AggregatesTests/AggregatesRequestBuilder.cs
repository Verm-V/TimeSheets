using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Tests.AggregatesTests
{
	public class AggregatesRequestBuilder
	{
		/// <summary>Запрос на создание случайной карточки учета</summary>
		public static SheetCreateRequest CreateRandomSheetCreateRequest()
		{
			var request = new SheetCreateRequest()
			{
				Amount = 8,
				ContractId = Guid.NewGuid(),
				Date = DateTime.Now,
				EmployeeId = Guid.NewGuid(),
				ServiceId = Guid.NewGuid(),
			};
			return request;
		}

		/// <summary>Запрос на создание случайного счета</summary>
		public static InvoiceCreateRequest CreateRandomInvoiceCreateRequest()
		{
			var request = new InvoiceCreateRequest()
			{
				ContractId = Guid.NewGuid(),
				DateStart = DateTime.MinValue,
				DateEnd = DateTime.Now,
			};
			return request;
		}

	}
}
