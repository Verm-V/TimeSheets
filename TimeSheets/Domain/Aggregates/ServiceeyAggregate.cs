using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Entities;

namespace TimeSheets.Domain.Aggregates
{
	public class ServiceAggregate : Service
	{
		//Запрещаем прямое создание пустого объекта
		private ServiceAggregate() { }

		/// <summary>Создание сервиса</summary>
		/// <param name="request">Запрос на создание сервиса</param>
		/// <returns>Новый сервис</returns>
		public static ServiceAggregate CreateFromServiceRequest(ServiceRequest request)
		{
			return new ServiceAggregate()
			{
				Id = Guid.NewGuid(),
				Name = request.Name,
				IsDeleted = false,			
			};
		}

		/// <summary>Обновление сервиса</summary>
		/// <param name="request">Запрос на обновление сервиса</param>
		public void UpdateFromServiceRequest(ServiceRequest request)
		{
			Name = request.Name;
		}



		/// <summary>Помечает сущность как удаленную</summary>
		public void MarkAsDeleted()
		{
			IsDeleted = true;
		}
	}
}
