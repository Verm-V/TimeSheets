using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Entities;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Implementation
{
	public class ContractManager : IContractManager
	{
		private readonly IContractRepo _repo;

		public ContractManager(IContractRepo repo)
		{
			_repo = repo;
		}

		public async Task<Contract> GetItem(Guid id)
		{
			return await _repo.GetItem(id);
		}

		public async Task<IEnumerable<Contract>> GetItems()
		{
			return await _repo.GetItems();
		}

		public async Task<Guid> Create(ContractCreateRequest request)
		{
			var contract = new Contract()
			{
				Id = Guid.NewGuid(),
				Title = request.Title,
				DateStart = request.DateStart,
				DateEnd = request.DateEnd,
				Description = request.Description,
				IsDeleted = false,
			};

			await _repo.Add(contract);

			return contract.Id;
		}

		public async Task Update(Guid id, ContractUpdateRequest request)
		{
			var item = await _repo.GetItem(id);
			if(item!=null)
			{
				item.Title = request.Title;
				item.Description = request.Description;

				await _repo.Update(item);
			}

		}

		public async Task<bool?> CheckContractIsActive(Guid id)
		{
			return await _repo.CheckContractIsActive(id);
		}

		public async Task<bool> CheckContractIsDeleted(Guid id)
		{
			return await _repo.CheckItemIsDeleted(id);
		}

		public async Task Delete(Guid id)
		{
			await _repo.Delete(id);
		}
	}
}
