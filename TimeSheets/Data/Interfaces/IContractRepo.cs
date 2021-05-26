using System;
using System.Threading.Tasks;
using TimeSheets.Models;

namespace TimeSheets.Data.Interfaces
{
	public interface IContractRepo : IRepoBase<Contract>
	{
		/// <summary>
		/// Проверяет является ли контракт активным
		/// </summary>
		/// <param name="id">Id проверяемого контракта</param>
		/// <returns>True - если контракт активен</returns>
		Task<bool?> CheckContractIsActive(Guid id);
	}
}
