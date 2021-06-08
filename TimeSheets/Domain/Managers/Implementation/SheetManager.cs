using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Entities;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Domain.Aggregates;
using System.Diagnostics.CodeAnalysis;

namespace TimeSheets.Domain.Implementation
{
	[ExcludeFromCodeCoverage]
	public class SheetManager : ISheetManager
	{
		private readonly ISheetRepo _repo;

		public SheetManager(ISheetRepo repo)
		{
			_repo = repo;
		}

		public async Task<SheetAggregate> GetItem(Guid id)
		{
			return await _repo.GetItem(id);
		}

		public async Task<IEnumerable<SheetAggregate>> GetItems()
		{
			return await _repo.GetItems();
		}

		public async Task<Guid> Create(SheetCreateRequest request)
		{
			var sheet = SheetAggregate.CreateFromRequest(request);

			await _repo.Add(sheet);

			return sheet.Id;
		}

		public async Task Approve(Guid id)
		{
			var sheet = await _repo.GetItem(id);
			sheet.ApproveSheet();
			await _repo.Update(sheet);
		}

		public async Task Delete(Guid id)
		{
			await _repo.Delete(id);
		}
	}
}
