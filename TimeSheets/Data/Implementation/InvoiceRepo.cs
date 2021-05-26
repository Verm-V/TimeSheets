using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Data.Implementation
{
	public class InvoiceRepo : IInvoiceRepo
	{
		private readonly TimeSheetDbContext _context;

		public InvoiceRepo(TimeSheetDbContext context)
		{
			_context = context;
		}

		public async Task Add(Invoice item)
		{
			await _context.Invoices.AddAsync(item);
			await _context.SaveChangesAsync();
		}

		public async Task<bool> CheckItemIsDeleted(Guid id)
		{
			var item = await _context.Invoices.FindAsync(id);
			return item.IsDeleted;
		}

		public async Task<Invoice> GetItem(Guid id)
		{
			var result = await _context.Invoices.FindAsync(id);
			return result;
		}

		public async Task<IEnumerable<Invoice>> GetItems()
		{
			return await _context.Invoices.ToListAsync();
		}

		public async Task Update(Invoice item)
		{
			_context.Invoices.Update(item);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Guid id)
		{
			var item = await _context.Invoices.FindAsync(id);
			if (item != null)
			{
				item.IsDeleted = true;
				_context.Invoices.Update(item);
				await _context.SaveChangesAsync();
			}
		}

	}
}
