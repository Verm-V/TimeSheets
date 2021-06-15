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
	public class InvoiceRepo : IInvoiceRepo
	{
		private readonly TimeSheetDbContext _context;

		public InvoiceRepo(TimeSheetDbContext context)
		{
			_context = context;
		}

		public async Task Add(InvoiceAggregate item)
		{
			await _context.Invoices.AddAsync(item);
			await _context.SaveChangesAsync();
		}

		public async Task<bool> CheckItemIsDeleted(Guid id)
		{
			var item = await _context.Invoices.FindAsync(id);
			return item.IsDeleted;
		}

		public async Task<InvoiceAggregate> GetItem(Guid id)
		{
			var result = await _context.Invoices.FindAsync(id);
			return result;
		}

		public async Task<IEnumerable<InvoiceAggregate>> GetItems()
		{
			return await _context.Invoices.ToListAsync();
		}

		public async Task Update(InvoiceAggregate item)
		{
			_context.Invoices.Update(item);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Guid id)
		{
			var item = await _context.Invoices.FindAsync(id);
			if (item != null)
			{
				item.MarkAsDeleted();
				_context.Invoices.Update(item);
				await _context.SaveChangesAsync();
			}
		}
		public async Task<IEnumerable<SheetAggregate>> GetSheets(
			Guid contractId,
			DateTime dateStart,
			DateTime dateEnd)
		{
			var sheets = await _context.Sheets
				.Where(x => x.ContractId == contractId)
				.Where(x => x.Date <= dateEnd && x.Date >= dateStart)
				.Where(x => x.InvoiceId == null)
				.ToListAsync();

			return sheets;
		}

	}
}
