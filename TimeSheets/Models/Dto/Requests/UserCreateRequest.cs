using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models.Dto.Requests
{
	/// <summary>Запрос на создание пользователя системы</summary>
	public class UserCreateRequest
	{
		/// <summary>Имя пользователя</summary>
		public string Username { get; set; }

		/// <summary>Пароль пользователя</summary>
		public string Password { get; set; }

		/// <summary>Роль пользователя</summary>
		public string Role { get; set; }
	}
}
