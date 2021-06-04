﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models.Entities;

namespace TimeSheets.Data.Implementation
{
	public class UserRepo : IUserRepo
	{
		private readonly TimeSheetDbContext _context;

		public UserRepo(TimeSheetDbContext context)
		{
			_context = context;
		}

		public async Task Add(User item)
		{
			await _context.Users.AddAsync(item);
			await _context.SaveChangesAsync();
		}

		public async Task<bool> CheckItemIsDeleted(Guid id)
		{
			var item = await _context.Users.FindAsync(id);
			return item.IsDeleted;
		}

		public async Task<User> GetItem(Guid id)
		{
			var result = await _context.Users.FindAsync(id);
			return result;
		}

		public async Task<User> GetItem(string login, byte[] passwordHash)
		{
			return await _context.Users
				.FirstOrDefaultAsync(x => x.Username == login && x.PasswordHash == passwordHash);
		}

		public async Task<IEnumerable<User>> GetItems()
		{
			return await _context.Users.ToListAsync();
		}

		public async Task Update(User item)
		{
			_context.Users.Update(item);
			await _context.SaveChangesAsync();
		}

		public async Task Delete(Guid id)
		{
			var item = await _context.Users.FindAsync(id);
			if (item != null)
			{
				item.IsDeleted = true;
				_context.Users.Update(item);
				await _context.SaveChangesAsync();
			}
		}

	}
}
