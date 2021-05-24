using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Interfaces
{
	public interface IUserManager
	{
		/// <summary>Проверка на то помечен ли пользователь как удаленный</summary>
		/// <param name="id">Id проверяемого пользователя</param>
		/// <returns>True если пользователь помечен как удаленный</returns>
		Task<bool> CheckUserIsDeleted(Guid id);

		/// <summary>Возвращает несколько пользователей</summary>
		/// <returns>Коллекция содержащая пользователей</returns>
		Task<IEnumerable<User>> GetItems();

		/// <summary>Выдает пользователя по его Id</summary>
		/// <param name="id">Id искомого пользователя</param>
		/// <returns>Искомый пользователь</returns>
		Task<User> GetItem(Guid id);

		/// <summary>Создает новый пользователь</summary>
		/// <param name="request">Запрос на создание нового пользователя</param>
		/// <returns>Id созданного пользователя</returns>
		Task<Guid> Create(UserRequest request);

		/// <summary>Изменяет существующий пользователь</summary>
		/// <param name="id">Id пользователя</param>
		/// <param name="request">Запрос на изменение пользователя</param>
		Task Update(Guid id, UserRequest request);

		/// <summary>Удаляет пользователя из репозитория</summary>
		/// <param name="id">Id пользователя</param>
		Task Delete(Guid id);
	}
}
