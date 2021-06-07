using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TimeSheets.Models.Dto.Auth
{
	/// <summary>Опции Jwt токена</summary>
	[ExcludeFromCodeCoverage]
	public class JwtOptions
	{
		/// <summary>Издатель токена</summary>
		public string Issuer { get; set; }

		/// <summary>Аудитория потребления токена</summary>
		public string Audience { get; set; }

		/// <summary>Ключ-подпись</summary>
		public string SigningKey { get; set; }

		/// <summary>Время жизни токена</summary>
		public int Lifetime { get; set; }

		public TokenValidationParameters GetTokenValidationParameters()
		{
			return new TokenValidationParameters()
			{
				ValidateIssuer = false,
				ValidIssuer = Issuer,
				ValidateAudience = false,
				ValidAudience = Audience,
				ValidateLifetime = true,
				IssuerSigningKey = GetSymmetricSecurityKey(),
				ValidateIssuerSigningKey = true,
				RoleClaimType = ClaimsIdentity.DefaultRoleClaimType
			};
		}

		private SymmetricSecurityKey GetSymmetricSecurityKey()
		{
			return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SigningKey));
		}

		public JwtSecurityToken GenerateToken(IEnumerable<Claim> claims)
		{
			var now = DateTime.UtcNow;

			var jwt = new JwtSecurityToken(
				issuer: Issuer,
				audience: Audience,
				notBefore: now,
				claims: claims,
				expires: now.Add(TimeSpan.FromMinutes(Lifetime)),
				signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(),
					SecurityAlgorithms.HmacSha256));

			return jwt;
		}
	}
}
