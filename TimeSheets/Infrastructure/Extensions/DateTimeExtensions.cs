﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheets.Infrastructure.Extensions
{
	public static class DateTimeExtensions
	{
		private static readonly DateTime Epoch =
			new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

		/// <summary></summary>
		public static long ToEpochTime(this DateTime dateTime) => (long)(dateTime - Epoch).TotalSeconds;
	}
}
