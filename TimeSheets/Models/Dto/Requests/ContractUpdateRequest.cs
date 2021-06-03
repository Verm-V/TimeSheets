using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models.Dto.Requests
{
	/// <summary>Запрос на изменение контракта</summary>
	public class ContractUpdateRequest
	{
		/// <summary>Наименование контракта</summary>
		public string Title { get; set; }

		/// <summary>Описание контракта</summary>
		public string Description { get; set; }
	}
}
