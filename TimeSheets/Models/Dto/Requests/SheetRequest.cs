using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models.Dto.Requests
{
	/// <summary>Запрос для карточки учета затраченного времени</summary>
	public class SheetRequest
	{
		/// <summary>Дата за которую регистрируется работа</summary>
		public DateTime Date { get; set; }
		
		/// <summary>Id работника</summary>
		public Guid EmployeeId { get; set; }

		/// <summary>Id контракта</summary>
		public Guid ContractId { get; set; }

		/// <summary>Id оказываемой услуги</summary>
		public Guid ServiceId { get; set; }

		/// <summary>Количество часов затраченных на выполнение услуги</summary>
		public int Amount { get; set; }
	}
}
