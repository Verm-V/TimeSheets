using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Entities;
using TimeSheets.Models.Dto.Requests;
using System.Diagnostics.CodeAnalysis;
using TimeSheets.Domain.Aggregates;

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

		public async Task<ClientAggregate> GetItem(Guid id)
		{
			return await _repo.GetItem(id);
		}

		public async Task<IEnumerable<ClientAggregate>> GetItems()
		{
			return await _repo.GetItems();
		}

		public async Task<Guid> Create(ClientCreateRequest request)
		{
			var client = ClientAggregate.CreateFromClientRequest(request);

			await _repo.Add(client);

			return client.Id;
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
