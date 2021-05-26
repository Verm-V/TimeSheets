using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models;
using TimeSheets.Models.Dto.Responses;

namespace TimeSheets.Domain.Interfaces
{
	public interface ILoginManager
	{
		/// <summary>Аутентификация пользователя</summary>
		/// <param name="user">Пользователь</param>
		/// <returns>Результат аутентификации пользователя</returns>
		Task<LoginResponse> Authenticate(User user);
	}
}
