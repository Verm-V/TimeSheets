using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models;
using TimeSheets.Models.Dto.Auth;
using TimeSheets.Models.Dto.Responses;
using TimeSheets.Infrastructure.Extensions;
using TimeSheets.Data.Interfaces;
using System;

namespace TimeSheets.Domain.Implementation
{
	public class LoginManager : ILoginManager
	{
		private readonly JwtAccessOptions _jwtAccessOptions;
		private readonly JwtRefreshOptions _jwtRefreshOptions;

		private readonly IUserRepo _userRepo;

		public LoginManager(
			IOptions<JwtAccessOptions> jwtAccessOptions,
			IOptions<JwtRefreshOptions> jwtRefreshOptions,
			IUserRepo userRepo)
		{
			_jwtAccessOptions = jwtAccessOptions.Value;
			_jwtRefreshOptions = jwtRefreshOptions.Value;
			_userRepo = userRepo;
		}

		/// <summary>Аутентификация пользователя</summary>
		/// <param name="user">Пользователь</param>
		/// <returns>Набор токенов доступа и обновления</returns>
		public async Task<LoginResponse> Authenticate(User user)
		{
			// Создание списка Claim'ов
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
				new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
				new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
			};

			// Генерация Access и Refresh токенов
			var accessTokenRaw = _jwtAccessOptions.GenerateToken(claims);
			var refreshTokenRaw = _jwtRefreshOptions.GenerateToken(claims);

			var securityHandler = new JwtSecurityTokenHandler();

			var accessToken = securityHandler.WriteToken(accessTokenRaw);
			var refreshToken = securityHandler.WriteToken(refreshTokenRaw);

			// Запись Refresh токена в базу к соответствующему пользователю
			var userId = Guid.Parse(claims[0].Value);
			var userInfo = await _userRepo.GetItem(userId);
			userInfo.RefreshToken = refreshToken;
			await _userRepo.Update(userInfo);

			// Формирование ответа от сервера
			var loginResponse = new LoginResponse()
			{
				AccessToken = accessToken,
				ExpiresIn = accessTokenRaw.ValidTo.ToEpochTime(),
				RefreshToken = refreshToken,
			};

			return loginResponse;
		}
	}
}
