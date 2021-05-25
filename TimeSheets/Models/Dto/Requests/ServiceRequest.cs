using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models.Dto.Requests
{
	/// <summary>Запрос для предоставляемой услуге</summary>
	public class ServiceRequest
	{
		/// <summary>Наименование услуги</summary>
		public string Name { get; set; }
	}
}
