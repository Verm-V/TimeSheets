﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
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

		public async Task Add(Service item)
		{
			await _context.Services.AddAsync(item);
			await _context.SaveChangesAsync();
		}

		public async Task<bool> CheckItemIsDeleted(Guid id)
		{
			var item = await _context.Services.FindAsync(id);
			return item.IsDeleted;
		}

		public async Task<Service> GetItem(Guid id)
		{
			var result = await _context.Services.FindAsync(id);
			return result;
		}

		public async Task<IEnumerable<Service>> GetItems()
		{
			return await _context.Services.ToListAsync();
		}

		public async Task Update(Service item)
		{
			_context.Services.Update(item);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Guid id)
		{
			var item = await _context.Services.FindAsync(id);
			if (item != null)
			{
				item.IsDeleted = true;
				_context.Services.Update(item);
				await _context.SaveChangesAsync();
			}
		}

	}
}
