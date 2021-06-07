using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models.Dto.Requests
{
	/// <summary>Запрос для сотрудника</summary>
	[ExcludeFromCodeCoverage]
	public class EmployeeCreateRequest
	{
		/// <summary>Id пользователя</summary>
		public Guid UserId { get; set; }

	}
}
