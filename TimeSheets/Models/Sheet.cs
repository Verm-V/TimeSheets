using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models
{
	/// <summary>Карточка учета затраченного времени сотрудником</summary>
	public class Sheet
	{
		/// <summary>Id карточки</summary>
		public Guid Id { get; set; }
	
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

		
		// Навигационные свойства
		public Employee Employee { get; set; }
		public Contract Contract { get; set; }
		public Service Service { get; set; }
		public Invoice Invoice { get; set; }

	}
}
