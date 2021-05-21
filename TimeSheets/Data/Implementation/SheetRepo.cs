using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Data.Interfaces;
using TimeSheets.Models;

namespace TimeSheets.Data.Implementation
{
	public class SheetRepo : ISheetRepo
	{
		public void Add(Sheet item)
		{
			GeneratedData.sheets.Add(item);
		}

		public Sheet GetItem(Guid id)
		{
			return GeneratedData.sheets.FirstOrDefault(x => x.Id == id);
		}

		public IEnumerable<Sheet> GetItems()
		{
			throw new NotImplementedException();
		}

		public void Update()
		{
			throw new NotImplementedException();
		}
	}
}
