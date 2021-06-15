using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Tests.AggregatesTests
{
	public class AggregatesRequestBuilder
	{
		/// <summary>Запрос на создание случайной карточки учета</summary>
		public static SheetCreateRequest CreateRandomSheetCreateRequest()
		{
			var request = new SheetCreateRequest()
			{
				Amount = 8,
				ContractId = Guid.NewGuid(),
				Date = DateTime.Now,
				EmployeeId = Guid.NewGuid(),
				ServiceId = Guid.NewGuid(),
			};
			return request;
		}

		/// <summary>Запрос на создание случайного счета</summary>
		public static InvoiceCreateRequest CreateRandomInvoiceCreateRequest()
		{
			var request = new InvoiceCreateRequest()
			{
				ContractId = Guid.NewGuid(),
				DateStart = DateTime.MinValue,
				DateEnd = DateTime.Now,
			};
			return request;
		}

		/// <summary>Запрос на создание случайного клиента</summary>
		public static ClientCreateRequest CreateRandomClientCreateRequest()
		{
			var request = new ClientCreateRequest()
			{
				UserId = Guid.NewGuid(),
			};
			return request;

		}

		/// <summary>Запрос на создание случайного контракта</summary>
		public static ContractCreateRequest CreateRandomContractCreateRequest()
		{
			var request = new ContractCreateRequest()
			{
				Title = "Contract Title",
				DateStart = DateTime.MinValue,
				DateEnd = DateTime.Now,
				Description = "Contract Description",
			};
			return request;

		}

		/// <summary>Запрос на обновление контракта</summary>
		public static ContractUpdateRequest CreateRandomContractUpdateRequest()
		{
			var request = new ContractUpdateRequest()
			{
				Title = "Contract Title",
				Description = "Contract Description",
			};
			return request;

		}


		/// <summary>Запрос на создание случайного работника</summary>
		public static EmployeeCreateRequest CreateRandomEmployeeCreateRequest()
		{
			var request = new EmployeeCreateRequest()
			{
				UserId = Guid.NewGuid(),
			};
			return request;

		}

		/// <summary>Запрос на создание случайного сервера</summary>
		public static ServiceRequest CreateRandomServiceRequest()
		{
			var request = new ServiceRequest()
			{
				Name = "Service Name",
			};
			return request;

		}

		/// <summary>Запрос на создание случайного пользователя</summary>
		public static UserCreateRequest CreateRandomUserCreateRequest()
		{
			var request = new UserCreateRequest()
			{
				Username = "Username",
				Password = "Password",
				Role = "Role",
			};
			return request;

		}

		/// <summary>Запрос на обновление пользователя</summary>
		public static UserUpdateRequest CreateRandomUserUpdateRequest()
		{
			var request = new UserUpdateRequest()
			{
				Username = "Username",
				Password = "Password",
				Role = "Role",
			};
			return request;

		}


	}
}
