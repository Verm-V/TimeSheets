using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Models.Entities;

namespace TimeSheets.Data.Interfaces
{
	public interface ISheetRepo : IRepoBase<SheetAggregate>
	{
	}
}
