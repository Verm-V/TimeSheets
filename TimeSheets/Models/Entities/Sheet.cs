using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Domain.ValueObjects;

namespace TimeSheets.Models.Entities
{
	/// <summary>Карточка учета затраченного времени сотрудником</summary>
	[ExcludeFromCodeCoverage]
	public class Sheet
	{
		/// <summary>Id карточки</summary>
		public Guid Id { get; protected set; }
	
		/// <summary>Дата за которую регистрируется работа</summary>
		public DateTime Date { get; protected set; }
	
		/// <summary>Id работника</summary>
		public Guid EmployeeId { get; protected set; }
	
		/// <summary>Id контракта</summary>
		public Guid ContractId { get; protected set; }
	
		/// <summary>Id оказываемой услуги</summary>
		public Guid ServiceId { get; protected set; }
	
		/// <summary>Id счета выставляемого клиенту</summary>
		public Guid? InvoiceId { get; protected set; }
		
		/// <summary>Количество часов затраченных на выполнение услуги</summary>
		public SpentTime Amount { get; protected set; }

		/// <summary>Пометка о том, что карточка удалена</summary>
		public bool IsDeleted { get; protected set; }

		/// <summary>Флаг подтверждения карточки</summary>
		public bool IsApproved { get; protected set; }

		/// <summary>Дата подтверждения карточки</summary>
		public DateTime ApprovedDate { get; protected set; }


		// Навигационные свойства
		public Employee Employee { get; set; }
		public Contract Contract { get; set; }
		public Service Service { get; set; }
		public InvoiceAggregate Invoice { get; set; }

	}
}
