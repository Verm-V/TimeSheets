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
		public async Task Add(Employee item)
		{
			throw new NotImplementedException();
		}

		public Task<bool> CheckItemIsDeleted(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<Employee> GetItem(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Employee>> GetItems()
		{
			throw new NotImplementedException();
		}

		public async Task Update(Employee item)
		{
			throw new NotImplementedException();
		}
	}
}
