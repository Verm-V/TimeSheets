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
		public void Add(Service item)
		{
			throw new NotImplementedException();
		}

		public Service GetItem(Guid id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Service> GetItems()
		{
			throw new NotImplementedException();
		}

		public void Update()
		{
			throw new NotImplementedException();
		}
	}
}
