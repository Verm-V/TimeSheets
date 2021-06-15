using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Models.Entities;

namespace TimeSheets.Data.Interfaces
{
	public interface IUserRepo : IRepoBase<UserAggregate>
	{
		/// <summary>Извлечение пользователя из хранилища по логину и паролю</summary>
		/// <param name="login">Логин</param>
		/// <param name="passwordHash">Хэш пароля</param>
		/// <returns>Пользователь удовлетворяющий условиям</returns>
		Task<UserAggregate> GetItem(string login, byte[] passwordHash);
	}
}
