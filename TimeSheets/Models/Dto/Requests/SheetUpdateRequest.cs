using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models.Dto.Requests
{
	/// <summary>Запрос на изменение карточки учета затраченного времени</summary>
	[ExcludeFromCodeCoverage]
	public class SheetUpdateRequest
	{
		/// <summary>Количество часов затраченных на выполнение услуги</summary>
		public int Amount { get; set; }
	}
}
