using System;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models;
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

		public async Task<Guid> Create(ContractCreateRequest request)
		{
			var contract = new Contract()
			{
				Id = Guid.NewGuid(),
				Title = request.Title,
				DateStart = request.DateStart,
				DateEnd = request.DateEnd,
				Description = request.Description
			};

			await _repo.Add(contract);

			return contract.Id;
		}

		public async Task<bool?> CheckContractIsActive(Guid id)
		{
			return await _repo.CheckContractIsActive(id);
		}
	}
}
