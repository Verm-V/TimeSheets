using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models.Dto.Requests
{
	/// <summary>Запрос на создание/изменение предоставляемой услуги</summary>
	[ExcludeFromCodeCoverage]
	public class ServiceRequest
	{
		/// <summary>Наименование услуги</summary>
		public string Name { get; set; }
	}
}
