using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models.Entities;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Dto.Responses;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Domain.Interfaces
{
	public interface ILoginManager
	{
		/// <summary>Аутентификация пользователя</summary>
		/// <param name="user">Пользователь</param>
		/// <returns>Результат аутентификации пользователя</returns>
		Task<LoginResponse> Authenticate(UserAggregate user);

		/// <summary>Генерация нового Access токена по Refresh токену</summary>
		/// <param name="request"></param>
		/// <returns>Новый токен доступа</returns>
		Task<LoginResponse> Refresh(RefreshRequest request);
	}
}
