﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Implementation
{
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

		public async Task<Guid> Create(ClientRequest request)
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

		public async Task Update(Guid id, ClientRequest request)
		{
			var item = await _repo.GetItem(id);
			if (item != null)
			{
				item.UserId = request.UserId;

				await _repo.Update(item);
			}
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
