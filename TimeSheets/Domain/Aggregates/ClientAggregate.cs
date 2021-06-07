using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Entities;

namespace TimeSheets.Domain.Aggregates
{
	public class ClientAggregate : Client
	{
		//Запрещаем прямое создание пустого объекта
		private ClientAggregate() { }

		/// <summary>Создание клиента</summary>
		/// <param name="request">Запрос на создание клиента</param>
		/// <returns>Новый клиент</returns>
		public static ClientAggregate CreateFromClientRequest(ClientCreateRequest request)
		{
			return new ClientAggregate()
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
