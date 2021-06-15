using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Domain.Aggregates;

namespace TimeSheets.Models.Entities
{
	/// <summary>Информация о пользователе системы</summary>
	[ExcludeFromCodeCoverage]
	public class User
	{
		/// <summary>Id пользователя</summary>
		public Guid Id { get; protected set; }
	
		/// <summary>Имя пользователя</summary>
		public string Username { get; protected set; }

		/// <summary>Пометка о том, что пользователь удален</summary>
		public bool IsDeleted { get; protected set; }

		/// <summary>Хэш пароля</summary>
		public byte[] PasswordHash { get; protected set; }

		/// <summary>Роль пользователя</summary>
		public string Role { get; protected set; }

		/// <summary>Refresh token</summary>
		public string RefreshToken { get; protected set; }



		// Навигационные свойства
		public ClientAggregate Client { get; set; }
		public EmployeeAggregate Employee { get; set; }

	}
}
