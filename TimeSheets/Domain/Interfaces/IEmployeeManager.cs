using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Domain.Interfaces
{
	public interface IEmployeeManager
	{
		/// <summary>Проверка на то помечен ли сотрудник как удаленный</summary>
		/// <param name="id">Id проверяемого сотрудника</param>
		/// <returns>True если сотрудник помечен как удаленный</returns>
		Task<bool> CheckEmployeeIsDeleted(Guid id);

		/// <summary>Возвращает несколько содтрудников</summary>
		/// <returns>Коллекция содержащая сотрудников</returns>
		Task<IEnumerable<Employee>> GetItems();

		/// <summary>Выдает сотрудника по его Id</summary>
		/// <param name="id">Id искомого сотрудника</param>
		/// <returns>Искомый сотрудник</returns>
		Task<Employee> GetItem(Guid id);

		/// <summary>Создает новый сотрудник</summary>
		/// <param name="request">Запрос на создание нового сотрудника</param>
		/// <returns>Id созданного сотрудника</returns>
		Task<Guid> Create(EmployeeRequest request);

		/// <summary>Изменяет существующий сотрудник</summary>
		/// <param name="id">Id сотрудника</param>
		/// <param name="request">Запрос на изменение сотрудника</param>
		Task Update(Guid id, EmployeeRequest request);

		/// <summary>Удаляет сотрудника из репозитория</summary>
		/// <param name="id">Id сотрудника</param>
		Task Delete(Guid id);
	}
}
