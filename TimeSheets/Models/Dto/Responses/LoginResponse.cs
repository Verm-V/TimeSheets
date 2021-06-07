using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models.Dto.Responses
{
	/// <summary>Результат аутентификации пользователя</summary>
	[ExcludeFromCodeCoverage]
	public class LoginResponse
	{
		/// <summary>Токен доступа</summary>
		public string AccessToken { get; set; }
		/// <summary>Токен обновления</summary>
		public string RefreshToken { get; set; }
		/// <summary>Срок действия</summary>
		public long ExpiresIn { get; set; }
	}
}
