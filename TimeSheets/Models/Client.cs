using System;
using System.Collections.Generic;
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
		public Guid User { get; set; }
	}
}
