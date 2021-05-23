using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Interfaces
{
	/// <summary>Менеджер запросов к данным по карточкам учета</summary>
	public interface ISheetManager
	{
		/// <summary>Возвращает карточку по ее Id</summary>
		/// <param name="id"></param>
		/// <returns>Искомая карточка</returns>
		Task<Sheet> GetItem(Guid id);

		/// <summary>Возвращает несколько карточек</summary>
		/// <returns>Коллекция содержащая карточки</returns>
		Task<IEnumerable<Sheet>> GetItems();

		/// <summary>Создает новую карточку</summary>
		/// <param name="request">Запрос на создание карточки</param>
		/// <returns>Id созданной карточки</returns>
		Task<Guid> Create(SheetRequest request);

		/// <summary>Изменяет существующую карточку</summary>
		/// <param name="id">Id карточки</param>
		/// <param name="request">Запрос на изменение карточки</param>
		/// <returns></returns>
		Task Update(Guid id, SheetRequest request);
	}
}
