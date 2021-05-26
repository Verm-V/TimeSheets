using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Interfaces
{
	public interface IUserManager : IBaseManager<User, UserRequest>
	{
		/// <summary> Возвращает пользователя по логину и паролю </summary>
		Task<User> GetItem(LoginRequest request);
	}
}
