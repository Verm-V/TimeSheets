using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models.Dto.Requests
{
	/// <summary> Запрос на аутентификацию пользователя по логину и паролю </summary>
	public class LoginRequest
	{
		/// <summary>Логин</summary>
		public string Login { get; set; }

		/// <summary>Пароль</summary>
		public string Password { get; set; }
	}
}
