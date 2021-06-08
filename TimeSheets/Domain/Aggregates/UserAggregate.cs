using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TimeSheets.Infrastructure;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Models.Entities;

namespace TimeSheets.Domain.Aggregates
{
	public class UserAggregate : User
	{
		//Запрещаем прямое создание пустого объекта
		private UserAggregate() { }

		/// <summary>Создание пользователя</summary>
		/// <param name="request">Запрос на создание пользователя</param>
		/// <returns>Новый пользователь</returns>
		public static UserAggregate CreateFromRequest(UserCreateRequest request)
		{
			return new UserAggregate()
			{
				Id = Guid.NewGuid(),
				Username = request.Username,
				PasswordHash = Security.GetPasswordHash(request.Password),
				Role = request.Role,
				RefreshToken = String.Empty,
				IsDeleted = false,
			};
		}

		/// <summary>Обновление пользователя</summary>
		/// <param name="request">Запрос на обновление пользователя</param>
		public void UpdateFromRequest(UserUpdateRequest request)
		{
			Username = request.Username;
			PasswordHash = Security.GetPasswordHash(request.Password);
			Role = request.Role;
		}

		/// <summary>Помечает сущность как удаленную</summary>
		public void MarkAsDeleted()
		{
			IsDeleted = true;
		}

		public void UpdateRefreshToken(string refreshToken)
		{
			RefreshToken = refreshToken;
		}



	}
}
