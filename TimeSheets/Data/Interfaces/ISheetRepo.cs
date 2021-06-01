using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Models;

namespace TimeSheets.Data.Interfaces
{
	public interface ISheetRepo : IRepoBase<Sheet>
	{
		/// <summary>Возвращает набор карточек для формирования счета клиенту</summary>
		/// <param name="contractId">Id контракта</param>
		/// <param name="dateStart">Дата начала</param>
		/// <param name="dateEnd">Дата конца</param>
		/// <returns>Набор карточек удовлетворяющих условиям</returns>
		Task<IEnumerable<Sheet>> GetItemsForInvoice(
			Guid contractId,
			DateTime dateStart,
			DateTime dateEnd);
	}
}
