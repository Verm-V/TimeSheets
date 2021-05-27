using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models
{
	/// <summary>Информация о пользователе системы</summary>
	public class User
	{
		/// <summary>Id пользователя</summary>
		public Guid Id { get; set; }
	
		/// <summary>Имя пользователя</summary>
		public string Username { get; set; }

		/// <summary>Пометка о том, что пользователь удален</summary>
		public bool IsDeleted { get; set; }

		/// <summary>Хэш пароля</summary>
		public byte[] PasswordHash { get; set; }

		/// <summary>Роль пользователя</summary>
		public string Role { get; set; }

		/// <summary>Refresh token</summary>
		public string RefreshToken { get; set; }



		// Навигационные свойства
		public Client Client { get; set; }
		public Employee Employee { get; set; }

	}
}
