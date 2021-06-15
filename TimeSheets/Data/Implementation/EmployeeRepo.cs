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
	public class EmployeeRepo : IEmployeeRepo
	{
		private readonly TimeSheetDbContext _context;

		public EmployeeRepo(TimeSheetDbContext context)
		{
			_context = context;
		}

		public async Task Add(EmployeeAggregate item)
		{
			await _context.Employees.AddAsync(item);
			await _context.SaveChangesAsync();
		}

		public async Task<bool> CheckItemIsDeleted(Guid id)
		{
			var item = await _context.Employees.FindAsync(id);
			return item.IsDeleted;
		}

		public async Task<EmployeeAggregate> GetItem(Guid id)
		{
			var result = await _context.Employees.FindAsync(id);
			return result;
		}

		public async Task<IEnumerable<EmployeeAggregate>> GetItems()
		{
			return await _context.Employees.ToListAsync();
		}

		public async Task Update(EmployeeAggregate item)
		{
			_context.Employees.Update(item);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Guid id)
		{
			var item = await _context.Employees.FindAsync(id);
			if (item != null)
			{
				item.MarkAsDeleted();
				_context.Employees.Update(item);
				await _context.SaveChangesAsync();
			}
		}

	}
}
