using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Data.Implementation
{
	public class ClientRepo : IClientRepo
	{
		private readonly TimeSheetDbContext _context;

		public ClientRepo(TimeSheetDbContext context)
		{
			_context = context;
		}

		public async Task Add(Client item)
		{
			await _context.Clients.AddAsync(item);
			await _context.SaveChangesAsync();
		}

		public async Task<bool> CheckItemIsDeleted(Guid id)
		{
			var item = await _context.Clients.FindAsync(id);
			return item.IsDeleted;
		}

		public async Task<Client> GetItem(Guid id)
		{
			var result = await _context.Clients.FindAsync(id);
			return result;
		}

		public async Task<IEnumerable<Client>> GetItems()
		{
			return await _context.Clients.ToListAsync();
		}

		public async Task Update(Client item)
		{
			_context.Clients.Update(item);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Guid id)
		{
			var item = await _context.Clients.FindAsync(id);
			if (item != null)
			{
				item.IsDeleted = true;
				_context.Clients.Update(item);
				await _context.SaveChangesAsync();
			}
		}

	}
}
