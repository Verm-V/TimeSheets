using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Interfaces
{
	/// <summary>Менеджер запросов к данным по контрактам</summary>
	public interface IContractManager : IBaseManager<Contract, ContractRequest>
	{
		/// <summary>Проверяет является ли контракт действующим</summary>
		/// <param name="id">Id контракта</param>
		/// <returns>True - если контракт действующий, false - если нет, null - если такого контракта нет</returns>
		public Task<bool?> CheckContractIsActive(Guid id);
	}
}
