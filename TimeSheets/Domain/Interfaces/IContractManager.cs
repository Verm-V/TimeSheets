using System;
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

		/// <summary>Выдает контракт по его Id</summary>
		/// <param name="id">Id искомого контракта</param>
		/// <returns>Искомый контракт</returns>
		Task<Contract> GetItem(Guid id);

		/// <summary>Создает новый контракт</summary>
		/// <param name="request">Запрос на создание нового контракта</param>
		/// <returns>Id созданного контракта</returns>
		Task<Guid> Create(ContractCreateRequest request);

	}
}
