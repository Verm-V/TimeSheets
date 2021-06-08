using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Entities;

namespace TimeSheets.Domain.Aggregates
{
	public class ContractAggregate : Contract
	{
		//Запрещаем прямое создание пустого объекта
		private ContractAggregate() { }

		/// <summary>Создание контракта</summary>
		/// <param name="request">Запрос на создание контракта</param>
		/// <returns>Новый контракт</returns>
		public static ContractAggregate CreateFromContractRequest(ContractCreateRequest request)
		{
			return new ContractAggregate()
			{
				Id = Guid.NewGuid(),
				Title = request.Title,
				DateStart = request.DateStart,
				DateEnd = request.DateEnd,
				Description = request.Description,
				IsDeleted = false,
			};
		}

		/// <summary>Обновление контракта</summary>
		/// <param name="request">Запрос на обновление контракта</param>
		public void UpdateFromContractRequest(ContractUpdateRequest request)
		{
			Title = request.Title;
			Description = request.Description;
		}



		/// <summary>Помечает сущность как удаленную</summary>
		public void MarkAsDeleted()
		{
			IsDeleted = true;
		}
	}
}
