using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Entities;

namespace TimeSheets.Domain.Aggregates
{
	public class EmployeeAggregate : Employee
	{
		//Запрещаем прямое создание пустого объекта
		private EmployeeAggregate() { }

		/// <summary>Создание работника</summary>
		/// <param name="request">Запрос на создание работника</param>
		/// <returns>Новый работника</returns>
		public static EmployeeAggregate CreateFromEmployeeRequest(EmployeeCreateRequest request)
		{
			return new EmployeeAggregate()
			{
				Id = Guid.NewGuid(),
				UserId = request.UserId,
				IsDeleted = false,
			};
		}

		/// <summary>Помечает сущность как удаленную</summary>
		public void MarkAsDeleted()
		{
			IsDeleted = true;
		}
	}
}
