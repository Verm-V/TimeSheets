using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Infrastructure.Validation
{
	/// <summary>Сообщения об ошибках</summary>
	public class ValidationsMessages
	{
		public const string SheetAmountError = "Amount should be between 1 and 8.";
		public const string InvalidValue = "Incorrect value";
		public const string RequestDateStartError = "Start date should be less or equal than end date";
		public const string RequestDateEndError = "End date should be greater or equal than end date";
	}
}
