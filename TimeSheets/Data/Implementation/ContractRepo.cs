using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Models.Entities;

namespace TimeSheets.Data.Implementation
{
	[ExcludeFromCodeCoverage]
	public class ContractRepo : IContractRepo
	{
		private readonly TimeSheetDbContext _context;

		public ContractRepo(TimeSheetDbContext context)
		{
			_context = context;
		}

		public async Task Add(ContractAggregate item)
		{
			await _context.Contracts.AddAsync(item);
			await _context.SaveChangesAsync();
		}

		public async Task<bool?> CheckContractIsActive(Guid id)
		{
			var contract = await _context.Contracts.FindAsync(id);
			var now = DateTime.Now;
			var isActive = (now <= contract?.DateEnd && now >= contract?.DateStart);
			return isActive;
		}

		public async Task<bool> CheckItemIsDeleted(Guid id)
		{
			var item = await _context.Contracts.FindAsync(id);
			return item.IsDeleted;
		}

		public async Task<ContractAggregate> GetItem(Guid id)
		{
			var result = await _context.Contracts.FindAsync(id);
			return result;
		}

		public async Task<IEnumerable<ContractAggregate>> GetItems()
		{
			return await _context.Contracts.ToListAsync();
		}

		public async Task Update(ContractAggregate item)
		{
			_context.Contracts.Update(item);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Guid id)
		{
			var item = await _context.Contracts.FindAsync(id);
			if (item != null)
			{
				item.MarkAsDeleted();
				_context.Contracts.Update(item);
				await _context.SaveChangesAsync();
			}
		}

	}
}
