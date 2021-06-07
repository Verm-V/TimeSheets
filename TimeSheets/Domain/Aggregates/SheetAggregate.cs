using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Domain.ValueObjects;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Entities;

namespace TimeSheets.Domain.Aggregates
{
	public class SheetAggregate : Sheet
	{
		//Закрываем конструктор по умолчанию
		private SheetAggregate() { }

		/// <summary>Создание новой карточки учета времени</summary>
		/// <param name="request">Запрос на создание карточки</param>
		/// <returns>Новая карточка учета времени</returns>
		public static SheetAggregate CreateFromSheetRequest(SheetCreateRequest request)
		{
			return new SheetAggregate()
			{
				Id = Guid.NewGuid(),
				Amount = SpentTime.FromInt(request.Amount),
				ContractId = request.ContractId,
				Date = request.Date,
				EmployeeId = request.EmployeeId,
				ServiceId = request.ServiceId,
				IsDeleted = false,
			};
		}

		/// <summary>Подтверждение карточки</summary>
		public void ApproveSheet()
		{
			IsApproved = true;
			ApprovedDate = DateTime.Now;
		}

		/// <summary>Помечает сущность как удаленную</summary>
		public void MarkAsDeleted()
		{
			IsDeleted = true;
		}
	}
}
