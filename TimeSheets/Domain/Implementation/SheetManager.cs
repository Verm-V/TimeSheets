using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Implementation
{
	public class SheetManager : ISheetManager
	{
		private readonly ISheetRepo _repo;

		public SheetManager(ISheetRepo repo)
		{
			_repo = repo;
		}

		public async Task<Sheet> GetItem(Guid id)
		{
			return await _repo.GetItem(id);
		}

		public async Task<IEnumerable<Sheet>> GetItems()
		{
			return await _repo.GetItems();
		}

		public async Task<Guid> Create(SheetRequest request)
		{
			var sheet = new Sheet()
			{
				Id = Guid.NewGuid(),
				Amount = request.Amount,
				ContractId = request.ContractId,
				Date = request.Date,
				EmployeeId = request.EmployeeId,
				ServiceId = request.ServiceId,
			};

			await _repo.Add(sheet);

			return sheet.Id;
		}

		public async Task Update(Guid id, SheetRequest request)
		{
			var item = await _repo.GetItem(id);
			if(item != null)
			{
				item.Amount = request.Amount;
				item.ContractId = request.ContractId;
				item.Date = request.Date;
				item.EmployeeId = request.EmployeeId;
				item.ServiceId = request.ServiceId;

				await _repo.Update(item);
			}
		}

		public async Task Delete(Guid id)
		{
			await _repo.Delete(id);
		}
	}
}
