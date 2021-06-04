using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Models.Entities;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Domain.Interfaces
{
	public interface ISheetManager : IBaseManager<SheetAggregate, SheetCreateRequest>
	{
		/// <summary>Подтверждает указанную карточку</summary>
		/// <param name="id">Id подтверждаемой карточки</param>
		Task Approve(Guid id);
	}
}
