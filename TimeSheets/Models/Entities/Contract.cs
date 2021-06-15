using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Models.Entities
{
	/// <summary>Информация о контракте с клиентом</summary>
	[ExcludeFromCodeCoverage]
	public class Contract
	{
		/// <summary>Id контракта</summary>
		public Guid Id { get; protected set; }
	
		/// <summary>Наименование контракта</summary>
		public string Title { get; protected set; }
	
		/// <summary>Дата начала контракта</summary>
		public DateTime DateStart { get; protected set; }
	
		/// <summary>Дата окончания контракта</summary>
		public DateTime DateEnd { get; protected set; }
	
		/// <summary>Описание контракта</summary>
		public string Description { get; protected set; }

		/// <summary>Пометка о том, что контракт удален</summary>
		public bool IsDeleted { get; protected set; }



		// Навигационные свойства
		public ICollection<SheetAggregate> Sheets { get; set; }
		public ICollection<InvoiceAggregate> Invoices { get; set; }

	}
}
