using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Data.Implementation
{
	public class EmployeeRepo : IEmployeeRepo
	{
		private readonly TimeSheetDbContext _context;

		public EmployeeRepo(TimeSheetDbContext context)
		{
			_context = context;
		}

		public async Task Add(Employee item)
		{
			await _context.Employees.AddAsync(item);
			await _context.SaveChangesAsync();
		}

		public async Task<bool> CheckItemIsDeleted(Guid id)
		{
			var item = await _context.Employees.FindAsync(id);
			return item.IsDeleted;
		}

		public async Task<Employee> GetItem(Guid id)
		{
			var result = await _context.Employees.FindAsync(id);
			return result;
		}

		public async Task<IEnumerable<Employee>> GetItems()
		{
			return await _context.Employees.ToListAsync();
		}

		public async Task Update(Employee item)
		{
			_context.Employees.Update(item);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Guid id)
		{
			var item = await _context.Employees.FindAsync(id);
			if (item != null)
			{
				item.IsDeleted = true;
				_context.Employees.Update(item);
				await _context.SaveChangesAsync();
			}
		}

	}
}
