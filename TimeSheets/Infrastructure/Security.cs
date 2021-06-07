using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TimeSheets.Infrastructure
{
	public class Security
	{
		/// <summary>Добывает хэш пароля</summary>
		/// <param name="password">Хэшируемый пароль</param>
		/// <returns>SHA1 хэш пароля</returns>
		internal static byte[] GetPasswordHash(string password)
		{
			using (var sha1 = new SHA1CryptoServiceProvider())
			{
				return sha1.ComputeHash(Encoding.Unicode.GetBytes(password));
			}
		}
	}
}
