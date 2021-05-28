﻿using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models;
using TimeSheets.Models.Dto.Auth;
using TimeSheets.Models.Dto.Responses;
using TimeSheets.Infrastructure.Extensions;
using TimeSheets.Data.Interfaces;
using System;
using TimeSheets.Models.Dto.Requests;

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

		public async Task<LoginResponse> Authenticate(User user)
		{
			// Генерируем пару токенов
			var loginResponse = CreateTokensPair(user);

			// Запись Refresh токена в базу к соответствующему пользователю
			user.RefreshToken = loginResponse.RefreshToken;
			await _userRepo.Update(user);

			return loginResponse;
		}

		public async Task<LoginResponse> Refresh(RefreshRequest request)
		{
			// Извдекаем их токена дату до которой он действителен и Id пользователя
			var securityHandler = new JwtSecurityTokenHandler();
			var refreshTokenRaw = securityHandler.ReadJwtToken(request.RefreshToken);
			var validTo = refreshTokenRaw.ValidTo;

			var userId = Guid.Parse(refreshTokenRaw.Subject);

			// Достаем из базы пользователя на которого ссылается токен
			var user = await _userRepo.GetItem(userId);

			// Проверка на то, что пользователь существует, у него есть такой токен и он не протух.
			if(user == null || user.RefreshToken != request.RefreshToken || validTo < DateTime.Now)
			{
				throw new ArgumentException("Bad Refresh JWT-token");
			}

			// Генерируем пару токенов
			var loginResponse = CreateTokensPair(user);

			// Запись Refresh токена в базу к соответствующему пользователю
			user.RefreshToken = loginResponse.RefreshToken;
			await _userRepo.Update(user);

			return loginResponse;

		}

		/// <summary>Создает пару JWT токенов для пользователя</summary>
		/// <param name="user">Аутентифицируемый пользователь</param>
		/// <returns>Пара Access/refresh JWT токенов</returns>
		private LoginResponse CreateTokensPair(User user)
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
