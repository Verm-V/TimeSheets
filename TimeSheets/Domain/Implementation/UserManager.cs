using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Implementation
{
	public class UserManager : IUserManager
	{
		private readonly IUserRepo _repo;

		public UserManager(IUserRepo repo)
		{
			_repo = repo;
		}

		public async Task<User> GetItem(Guid id)
		{
			return await _repo.GetItem(id);
		}

		public async Task<User> GetItem(LoginRequest request)
		{
			var passwordHash = GetPasswordHash(request.Password);
			var user = await _repo.GetItem(request.Login, passwordHash);

			return user;
		}

		public async Task<IEnumerable<User>> GetItems()
		{
			return await _repo.GetItems();
		}

		public async Task<Guid> Create(UserCreateRequest request)
		{
			var User = new User()
			{
				Id = Guid.NewGuid(),
				Username = request.Username,
				PasswordHash = GetPasswordHash(request.Password),
				Role = request.Role,
				IsDeleted = false,
			};

			await _repo.Add(User);

			return User.Id;
		}

		public async Task Update(Guid id, UserUpdateRequest request)
		{
			var item = await _repo.GetItem(id);
			if(item!=null)
			{
				item.Username = request.Username;
				item.PasswordHash = GetPasswordHash(request.Password);
				item.Role = request.Role;
				await _repo.Update(item);
			}
		}

		public async Task<bool> CheckUserIsDeleted(Guid id)
		{
			return await _repo.CheckItemIsDeleted(id);
		}

		public async Task Delete(Guid id)
		{
			await _repo.Delete(id);
		}

		/// <summary>Добывает хэш пароля</summary>
		/// <param name="password">Хэшируемый пароль</param>
		/// <returns>SHA1 хэш пароля</returns>
		private static byte[] GetPasswordHash(string password)
		{
			using (var sha1 = new SHA1CryptoServiceProvider())
			{
				return sha1.ComputeHash(Encoding.Unicode.GetBytes(password));
			}
		}

	}
}
