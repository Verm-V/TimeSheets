using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models.Dto.Requests
{
	/// <summary>Запрос для клиента</summary>
	public class ClientCreateRequest
	{
		/// <summary>Id пользователя</summary>
		public Guid UserId { get; set; }
	}
}
