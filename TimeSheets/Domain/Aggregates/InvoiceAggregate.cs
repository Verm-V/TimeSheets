using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Domain.ValueObjects;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Entities;

namespace TimeSheets.Domain.Aggregates
{
	public class InvoiceAggregate : Invoice
	{
		/// <summary>Стоимость одного часа работы</summary>
		private readonly decimal _payRate = 100;

		//Запрещаем прямое создание пустого объекта
		private InvoiceAggregate() { }

		/// <summary>Создание счета</summary>
		/// <param name="request">Запрос на создание счета</param>
		/// <returns>Новый счет</returns>
		public static InvoiceAggregate CreateFromInvoiceRequest(InvoiceCreateRequest request)
		{
			return new InvoiceAggregate()
			{
				Id = Guid.NewGuid(),
				ContractId = request.ContractId,
				DateStart = request.DateStart,
				DateEnd = request.DateEnd,
			};
		}

		/// <summary>Добавление карточек учета времени к счету</summary>
		/// <param name="sheets">Набор карточек для включения в счет</param>
		public void IncludeSheets(IEnumerable<SheetAggregate> sheets)
		{
			Sheets.AddRange(sheets);
			CalculateSum();
		}

		/// <summary>Рассчет суммы счета</summary>
		private void CalculateSum()
		{
			var amount = Sheets.Sum(x => x.Amount.Amount * _payRate);
			Sum = Money.FromDecimal(amount);
		}

		/// <summary>Помечает сущность как удаленную</summary>
		public void MarkAsDeleted()
		{
			IsDeleted = true;
		}
	}

}
