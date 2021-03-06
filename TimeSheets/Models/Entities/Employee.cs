using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Models.Entities
{
	/// <summary>Информация о сотруднике</summary>
	[ExcludeFromCodeCoverage]
	public class Employee
	{
		/// <summary>Id сотрудника</summary>
		public Guid Id { get; protected set; }
	
		/// <summary>Id пользователя</summary>
		public Guid UserId { get; protected set; }

		/// <summary>Пометка о том, что сотрудник удален</summary>
		public bool IsDeleted { get; protected set; }



		// Навигационные свойства
		public UserAggregate User { get; set; }
		public ICollection<SheetAggregate> Sheets { get; set; }

	}
}
