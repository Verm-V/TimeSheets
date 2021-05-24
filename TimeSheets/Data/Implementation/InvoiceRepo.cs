using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Data.Implementation
{
	public class InvoiceRepo : IInvoiceRepo
	{
		public async Task Add(Invoice item)
		{
			throw new NotImplementedException();
		}

		public async Task<Invoice> GetItem(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Invoice>> GetItems()
		{
			throw new NotImplementedException();
		}

		public async Task Update(Invoice item)
		{
			throw new NotImplementedException();
		}
	}
}
