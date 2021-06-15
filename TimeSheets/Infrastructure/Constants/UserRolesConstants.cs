using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Infrastructure.Constants
{
	/// <summary>Роли пользователей в системе</summary>
	[ExcludeFromCodeCoverage]
	public class UserRolesConstants
	{
		/// <summary>Обычный пользователь</summary>
		public static string User = "user";

		/// <summary>Администратор</summary>
		public static string Admin = "admin";

		/// <summary>Клиент</summary>
		public static string Client = "client";

	}
}
