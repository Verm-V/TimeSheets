using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Domain.ValueObjects;
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
		/// <param name="contractId">Id контракта</param>
		/// <param name="dateStart">Дата начала периода выставления счета</param>
		/// <param name="dateEnd">Дата конца периода выставления счета</param>
		/// <returns>Новый счет</returns>
		public static InvoiceAggregate Create(Guid contractId, DateTime dateStart, DateTime dateEnd)
		{
			return new InvoiceAggregate()
			{
				Id = Guid.NewGuid(),
				ContractId = contractId,
				DateStart = dateStart,
				DateEnd = dateEnd,
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
