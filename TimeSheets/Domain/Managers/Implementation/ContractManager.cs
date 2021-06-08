using System;
using System.Collections.Generic;
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
	public class ContractManager : IContractManager
	{
		private readonly IContractRepo _repo;

		public ContractManager(IContractRepo repo)
		{
			_repo = repo;
		}

		public async Task<ContractAggregate> GetItem(Guid id)
		{
			return await _repo.GetItem(id);
		}

		public async Task<IEnumerable<ContractAggregate>> GetItems()
		{
			return await _repo.GetItems();
		}

		public async Task<Guid> Create(ContractCreateRequest request)
		{
			var contract = ContractAggregate.CreateFromContractRequest(request);

			await _repo.Add(contract);

			return contract.Id;
		}

		public async Task Update(Guid id, ContractUpdateRequest request)
		{
			var item = await _repo.GetItem(id);
			if(item!=null)
			{
				item.UpdateFromContractRequest(request);
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
