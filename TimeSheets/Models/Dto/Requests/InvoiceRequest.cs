using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models.Dto.Requests
{
	/// <summary>Запрос для счета</summary>
	public class InvoiceRequest
	{
		/// <summary>Id контракта</summary>
		public Guid ContractId { get; set; }

		/// <summary>Дата начала периода за который выставляется счет</summary>
		public DateTime DateStart { get; set; }

		/// <summary>Дата конца периода за который выставляется счет</summary>
		public DateTime DateEnd { get; set; }

	}
}
