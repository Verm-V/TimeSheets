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
	public class ServiceRepo : IServiceRepo
	{
		private readonly TimeSheetDbContext _context;

		public ServiceRepo(TimeSheetDbContext context)
		{
			_context = context;
		}

		public async Task Add(ServiceAggregate item)
		{
			await _context.Services.AddAsync(item);
			await _context.SaveChangesAsync();
		}

		public async Task<bool> CheckItemIsDeleted(Guid id)
		{
			var item = await _context.Services.FindAsync(id);
			return item.IsDeleted;
		}

		public async Task<ServiceAggregate> GetItem(Guid id)
		{
			var result = await _context.Services.FindAsync(id);
			return result;
		}

		public async Task<IEnumerable<ServiceAggregate>> GetItems()
		{
			return await _context.Services.ToListAsync();
		}

		public async Task Update(ServiceAggregate item)
		{
			_context.Services.Update(item);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Guid id)
		{
			var item = await _context.Services.FindAsync(id);
			if (item != null)
			{
				item.MarkAsDeleted();
				_context.Services.Update(item);
				await _context.SaveChangesAsync();
			}
		}

	}
}
