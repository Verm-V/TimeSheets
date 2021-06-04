using System;
using System.Collections.Generic;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Domain.ValueObjects;
using TimeSheets.Models;

namespace TimeSheets.Models.Entities
{
	/// <summary>Счета выставляемые клиентам</summary>
	public class Invoice
	{
		/// <summary>Id счета</summary>
		public Guid Id { get; protected set; }

		/// <summary>Id контракта</summary>
		public Guid ContractId { get; protected set; }

		/// <summary>Дата начала периода за который выставляется счет</summary>
		public DateTime DateStart { get; protected set; }

		/// <summary>Дата конца периода за который выставляется счет</summary>
		public DateTime DateEnd { get; protected set; }

		/// <summary>Сумма счета</summary>
		public decimal Sum { get; protected set; }

		/// <summary>Пометка о том, что счет удален</summary>
		public bool IsDeleted { get; protected set; }


		// Навигационные свойства
		public Contract Contract { get; set; }
		public List<SheetAggregate> Sheets { get; set; } = new List<SheetAggregate>();
	}
}