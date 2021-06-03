using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Interfaces
{
	public interface IUserManager : IBaseManager<User, UserCreateRequest>
	{
		/// <summary>Изменяет существующий объект</summary>
		/// <param name="id">Id изменямого объекта</param>
		/// <param name="request">Запрос на изменение объекта</param>
		Task Update(Guid id, UserUpdateRequest request);

		/// <summary> Возвращает пользователя по логину и паролю </summary>
		Task<User> GetItem(LoginRequest request);
	}
}
