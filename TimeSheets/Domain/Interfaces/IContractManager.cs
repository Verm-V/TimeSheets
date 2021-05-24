using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Interfaces
{
	/// <summary>Менеджер запросов к данным по контрактам</summary>
	public interface IContractManager
	{
		/// <summary>Проверка на то является ли контракт активным</summary>
		/// <param name="id">Id проверяемого контракта</param>
		/// <returns>True если контракт активен</returns>
		Task<bool?> CheckContractIsActive(Guid id);

		/// <summary>Проверка на то помечен ли контракт как удаленный</summary>
		/// <param name="id">Id проверяемого контракта</param>
		/// <returns>True если контракт помечен как удаленный</returns>
		Task<bool> CheckContractIsDeleted(Guid id);

		/// <summary>Возвращает несколько контрактов</summary>
		/// <returns>Коллекция содержащая контракты</returns>
		Task<IEnumerable<Contract>> GetItems();

		/// <summary>Выдает контракт по его Id</summary>
		/// <param name="id">Id искомого контракта</param>
		/// <returns>Искомый контракт</returns>
		Task<Contract> GetItem(Guid id);

		/// <summary>Создает новый контракт</summary>
		/// <param name="request">Запрос на создание нового контракта</param>
		/// <returns>Id созданного контракта</returns>
		Task<Guid> Create(ContractRequest request);
		
		/// <summary>Изменяет существующий контракт</summary>
		/// <param name="id">Id контракта</param>
		/// <param name="request">Запрос на изменение контракта</param>
		/// <returns></returns>
		Task Update(Guid id, ContractRequest request);

		/// <summary>Удаляет контракт из репозитория</summary>
		/// <param name="id">Id контракта</param>
		/// <returns></returns>
		Task Delete(Guid id);
	}
}
