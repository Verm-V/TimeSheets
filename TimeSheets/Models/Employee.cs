using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models
{
	/// <summary>Информация о сотруднике</summary>
	public class Employee
	{
		/// <summary>Id сотрудника</summary>
		public Guid Id { get; set; }
		/// <summary>Id пользователя</summary>
		public Guid UserId { get; set; }
	}
}
