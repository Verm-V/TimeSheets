﻿using System.Collections.Generic;
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

namespace TimeSheets.Domain.Implementation
{
	public class LoginManager : ILoginManager
	{
		private readonly JwtAccessOptions _jwtAccessOptions;
		private readonly JwtRefreshOptions _jwtRefreshOptions;

		public LoginManager(IOptions<JwtAccessOptions> jwtAccessOptions, IOptions<JwtRefreshOptions> jwtRefreshOptions)
		{
			_jwtAccessOptions = jwtAccessOptions.Value;
			_jwtRefreshOptions = jwtRefreshOptions.Value;
		}

		public async Task<LoginResponse> Authenticate(User user)
		{
			var claims = new List<Claim>
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
				new Claim(JwtRegisteredClaimNames.UniqueName, user.Username),
				new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
			};

			var accessTokenRaw = _jwtAccessOptions.GenerateToken(claims);
			var refreshTokenRaw = _jwtRefreshOptions.GenerateToken(claims);

			var securityHandler = new JwtSecurityTokenHandler();

			var accessToken = securityHandler.WriteToken(accessTokenRaw);
			var refreshToken = securityHandler.WriteToken(refreshTokenRaw);

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
