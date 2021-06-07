using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Models.Entities
{
	/// <summary>Информация о предоставляемой услуге в рамках контракта</summary>
	[ExcludeFromCodeCoverage]
	public class Service
	{
		/// <summary>Id услуги</summary>
		public Guid Id { get; set; }
	
		/// <summary>Наименование услуги</summary>
		public string Name { get; set; }

		/// <summary>Пометка о том, что услуга удалена</summary>
		public bool IsDeleted { get; set; }



		// Навигационные свойства
		public ICollection<SheetAggregate> Sheets { get; set; }

	}
}
