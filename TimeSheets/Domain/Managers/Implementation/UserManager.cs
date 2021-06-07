using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Entities;
using TimeSheets.Models.Dto.Requests;
using System.Diagnostics.CodeAnalysis;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Infrastructure;

namespace TimeSheets.Domain.Implementation
{
	[ExcludeFromCodeCoverage]
	public class UserManager : IUserManager
	{
		private readonly IUserRepo _repo;

		public UserManager(IUserRepo repo)
		{
			_repo = repo;
		}

		public async Task<UserAggregate> GetItem(Guid id)
		{
			return await _repo.GetItem(id);
		}

		public async Task<UserAggregate> GetItem(LoginRequest request)
		{
			var passwordHash = Security.GetPasswordHash(request.Password);
			var user = await _repo.GetItem(request.Login, passwordHash);

			return user;
		}

		public async Task<IEnumerable<UserAggregate>> GetItems()
		{
			return await _repo.GetItems();
		}

		public async Task<Guid> Create(UserCreateRequest request)
		{
			var user = UserAggregate.CreateFromUserRequest(request);

			await _repo.Add(user);

			return user.Id;
		}

		public async Task Update(Guid id, UserUpdateRequest request)
		{
			var item = await _repo.GetItem(id);
			item.UpdateFromUserRequest(request);
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
