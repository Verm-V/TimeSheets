using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Models.Entities;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Domain.Interfaces
{
	public interface IServiceManager : IBaseManager<ServiceAggregate, ServiceRequest>
	{
		/// <summary>Изменяет существующий объект</summary>
		/// <param name="id">Id изменямого объекта</param>
		/// <param name="request">Запрос на изменение объекта</param>
		Task Update(Guid id, ServiceRequest request);
	}
}
