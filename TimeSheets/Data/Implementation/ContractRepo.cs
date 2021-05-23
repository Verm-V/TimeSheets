using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Data.Implementation
{
	public class ContractRepo : IContractRepo
	{
		private readonly TimeSheetDbContext _context;

		public ContractRepo(TimeSheetDbContext context)
		{
			_context = context;
		}

		public async Task Add(Contract item)
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

		public async Task<Contract> GetItem(Guid id)
		{
			var result = await _context.Contracts.FindAsync(id);
			return result;
		}

		public async Task<IEnumerable<Contract>> GetItems()
		{
			throw new NotImplementedException();
		}

		public async Task Update(Contract item)
		{
			throw new NotImplementedException();
		}
	}
}
