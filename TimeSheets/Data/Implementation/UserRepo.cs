using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Data.Implementation
{
	public class UserRepo : IUserRepo
	{
		public async Task Add(User item)
		{
			throw new NotImplementedException();
		}

		public async Task<User> GetItem(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<User>> GetItems()
		{
			throw new NotImplementedException();
		}

		public async Task Update(User item)
		{
			throw new NotImplementedException();
		}
	}
}
