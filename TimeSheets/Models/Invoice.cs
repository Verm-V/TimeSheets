using System;
using System.Collections.Generic;
using TimeSheets.Models;

namespace TimeSheets.Models
{
	/// <summary>Счета выставляемые клиентам</summary>
	public class Invoice
	{
		/// <summary>Id счета</summary>
		public Guid Id { get; set; }

		/// <summary>Id контракта</summary>
		public Guid ContractId { get; set; }

		/// <summary>Дата начала периода за который выставляется счет</summary>
		public DateTime DateStart { get; set; }

		/// <summary>Дата конца периода за который выставляется счет</summary>
		public DateTime DateEnd { get; set; }

		/// <summary>Сумма счета</summary>
		public decimal Sum { get; set; }

		/// <summary>Пометка о том, что счет удален</summary>
		public bool IsDeleted { get; set; }


		// Навигационные свойства
		public Contract Contract { get; set; }
		public ICollection<Sheet> Sheets { get; set; }
	}
}