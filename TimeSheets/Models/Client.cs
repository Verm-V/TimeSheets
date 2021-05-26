﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models
{
	/// <summary>Информация о владельце контракта</summary>
	public class Client
	{
		/// <summary>Id владельца</summary>
		public Guid Id { get; set; }
	
		/// <summary>Id пользователя</summary>
		public Guid UserId { get; set; }

		/// <summary>Пометка о том, что клиент удален</summary>
		public bool IsDeleted { get; set; }


		// Навигационные свойства
		public User User { get; set; }


	}
}
