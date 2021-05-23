using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Data.Implementation
{
	public class ServiceRepo : IServiceRepo
	{
		public async Task Add(Service item)
		{
			throw new NotImplementedException();
		}

		public async Task<Service> GetItem(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Service>> GetItems()
		{
			throw new NotImplementedException();
		}

		public async Task Update(Service item)
		{
			throw new NotImplementedException();
		}
	}
}
