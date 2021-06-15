using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Models.Dto.Requests
{
	/// <summary> Запрос на обновление Access токена </summary>
	[ExcludeFromCodeCoverage]
	public class RefreshRequest
	{
		/// <summary>Токен обновления</summary>
		public string RefreshToken { get; set; }

	}
}
