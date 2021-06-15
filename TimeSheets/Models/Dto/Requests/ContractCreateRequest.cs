using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models.Dto.Requests
{
	/// <summary>Запрос на создание контракта</summary>
	[ExcludeFromCodeCoverage]
	public class ContractCreateRequest
	{
		/// <summary>Наименование контракта</summary>
		public string Title { get; set; }

		/// <summary>Дата начала контракта</summary>
		public DateTime DateStart { get; set; }

		/// <summary>Дата окончания контракта</summary>
		public DateTime DateEnd { get; set; }

		/// <summary>Описание контракта</summary>
		public string Description { get; set; }
	}
}
