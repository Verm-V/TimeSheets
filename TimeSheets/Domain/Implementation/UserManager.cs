using System;
using System.Collections.Generic;
using System.Linq;
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

		public async Task<IEnumerable<User>> GetItems()
		{
			return await _repo.GetItems();
		}

		public async Task<Guid> Create(UserRequest request)
		{
			var User = new User()
			{
				Id = Guid.NewGuid(),
				Username = request.Username,
				IsDeleted = false,
			};

			await _repo.Add(User);

			return User.Id;
		}

		public async Task Update(Guid id, UserRequest request)
		{
			var isDeleted = await CheckUserIsDeleted(id);
			var User = new User()
			{
				Id = id,
				Username = request.Username,
				IsDeleted = isDeleted,
			};

			await _repo.Update(User);

		}

		public async Task<bool> CheckUserIsDeleted(Guid id)
		{
			return await _repo.CheckItemIsDeleted(id);
		}

		public async Task Delete(Guid id)
		{
			await _repo.Delete(id);
		}
	}
}
