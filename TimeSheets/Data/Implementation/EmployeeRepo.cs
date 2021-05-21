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
		public void Add(Employee item)
		{
			throw new NotImplementedException();
		}

		public Employee GetItem(Guid id)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Employee> GetItems()
		{
			throw new NotImplementedException();
		}

		public void Update()
		{
			throw new NotImplementedException();
		}
	}
}
