using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models.Dto.Requests
{
	/// <summary>Запрос на изменение пользователя системы</summary>
	[ExcludeFromCodeCoverage]
	public class UserUpdateRequest
	{
		/// <summary>Имя пользователя</summary>
		public string Username { get; set; }

		/// <summary>Пароль пользователя</summary>
		public string Password { get; set; }

		/// <summary>Роль пользователя</summary>
		public string Role { get; set; }
	}
}
