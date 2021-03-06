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
	public class UserRepo : IUserRepo
	{
		private readonly TimeSheetDbContext _context;

		public UserRepo(TimeSheetDbContext context)
		{
			_context = context;
		}

		public async Task Add(UserAggregate item)
		{
			await _context.Users.AddAsync(item);
			await _context.SaveChangesAsync();
		}

		public async Task<bool> CheckItemIsDeleted(Guid id)
		{
			var item = await _context.Users.FindAsync(id);
			return item.IsDeleted;
		}

		public async Task<UserAggregate> GetItem(Guid id)
		{
			var result = await _context.Users.FindAsync(id);
			return result;
		}

		public async Task<UserAggregate> GetItem(string login, byte[] passwordHash)
		{
			return await _context.Users
				.FirstOrDefaultAsync(x => x.Username == login && x.PasswordHash == passwordHash);
		}

		public async Task<IEnumerable<UserAggregate>> GetItems()
		{
			return await _context.Users.ToListAsync();
		}

		public async Task Update(UserAggregate item)
		{
			_context.Users.Update(item);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Guid id)
		{
			var item = await _context.Users.FindAsync(id);
			if (item != null)
			{
				item.MarkAsDeleted();
				_context.Users.Update(item);
				await _context.SaveChangesAsync();
			}
		}

	}
}
