using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Data.Implementation
{
	public class ClientRepo : IClientRepo
	{
		public async Task Add(Client item)
		{
			throw new NotImplementedException();
		}

		public async Task<Client> GetItem(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Client>> GetItems()
		{
			throw new NotImplementedException();
		}

		public async Task Update(Client item)
		{
			throw new NotImplementedException();
		}
	}
}
