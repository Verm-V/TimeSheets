using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Entities;
using TimeSheets.Models.Dto.Requests;
using System.Diagnostics.CodeAnalysis;

namespace TimeSheets.Domain.Implementation
{
	[ExcludeFromCodeCoverage]
	public class ClientManager : IClientManager
	{
		private readonly IClientRepo _repo;

		public ClientManager(IClientRepo repo)
		{
			_repo = repo;
		}

		public async Task<Client> GetItem(Guid id)
		{
			return await _repo.GetItem(id);
		}

		public async Task<IEnumerable<Client>> GetItems()
		{
			return await _repo.GetItems();
		}

		public async Task<Guid> Create(ClientCreateRequest request)
		{
			var Client = new Client()
			{
				Id = Guid.NewGuid(),
				UserId = request.UserId,
				IsDeleted = false,
			};

			await _repo.Add(Client);

			return Client.Id;
		}

		public async Task<bool> CheckClientIsDeleted(Guid id)
		{
			return await _repo.CheckItemIsDeleted(id);
		}

		public async Task Delete(Guid id)
		{
			await _repo.Delete(id);
		}
	}
}
