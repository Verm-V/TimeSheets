using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data;
using TimeSheets.Data.Interfaces;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Models.Entities;

namespace TimeSheets.Data.Implementation
{
	public class SheetRepo : ISheetRepo
	{
		private readonly TimeSheetDbContext _context;

		public SheetRepo(TimeSheetDbContext context)
		{
			_context = context;
		}

		public async Task Add(SheetAggregate item)
		{
			await _context.Sheets.AddAsync(item);
			await _context.SaveChangesAsync();
		}

		public async Task<bool> CheckItemIsDeleted(Guid id)
		{
			var item = await _context.Sheets.FindAsync(id);
			return item.IsDeleted;
		}

		public async Task Delete(Guid id)
		{
			var item = await _context.Sheets.FindAsync(id);
			if (item != null)
			{
				item.MarkAsDeleted();
				_context.Sheets.Update(item);
				await _context.SaveChangesAsync();
			}
		}

		public async Task<SheetAggregate> GetItem(Guid id)
		{
			var result = await _context.Sheets.FindAsync(id);
			return result;
		}

		public async Task<IEnumerable<SheetAggregate>> GetItems()
		{
			return await _context.Sheets.ToListAsync();
		}

		public async Task Update(SheetAggregate item)
		{
			_context.Sheets.Update(item);
			await _context.SaveChangesAsync();
		}

	}
}
