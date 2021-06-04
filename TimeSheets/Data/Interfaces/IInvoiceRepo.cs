using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Models.Entities;

namespace TimeSheets.Data.Interfaces
{
	public interface IInvoiceRepo : IRepoBase<InvoiceAggregate>
	{
		/// <summary>
		/// Извлекает из хранилища набор карточек за заданный период времени 
		/// и относящиеся к заданному контракту
		/// </summary>
		/// <param name="contractId">Id контракта</param>
		/// <param name="dateStart">Начало временного периода</param>
		/// <param name="dateEnd">Окончание временного периода</param>
		/// <returns>Набор карточек соответствующих условию</returns>
		Task<IEnumerable<SheetAggregate>> GetSheets(
			Guid contractId,
			DateTime dateStart,
			DateTime dateEnd);

	}
}
