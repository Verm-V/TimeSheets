using System.Threading.Tasks;
using TimeSheets.Models;

namespace TimeSheets.Data.Interfaces
{
	public interface IUserRepo : IRepoBase<User>
	{
		/// <summary>Извлечение пользователя из хранилища по логину и паролю</summary>
		/// <param name="login">Логин</param>
		/// <param name="passwordHash">Хэш пароля</param>
		/// <returns>Пользователь удовлетворяющий условиям</returns>
		Task<User> GetItem(string login, byte[] passwordHash);
	}
}
