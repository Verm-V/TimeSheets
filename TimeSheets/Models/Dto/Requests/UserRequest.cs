using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models.Dto.Requests
{
	/// <summary>Запрос для пользователя системы</summary>
	public class UserRequest
	{
		/// <summary>Имя пользователя</summary>
		public string Username { get; set; }
	}
}
