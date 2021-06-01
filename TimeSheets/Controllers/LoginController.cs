using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Dto.Responses;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Controllers
{
	/// <summary>Аутентификация пользователей</summary>
	[Route("api")]
	public class LoginController : TimeSheetBaseController
	{
		private readonly IUserManager _userManager;
		private readonly ILoginManager _loginManager;

		public LoginController(ILoginManager loginManager, IUserManager userManager)
		{
			_loginManager = loginManager;
			_userManager = userManager;
		}

		/// <summary>Аутентификация пользователя</summary>
		/// <param name="request">Запрос на аутентификацию пользователя</param>
		/// <returns>Пара Access/Refresh JWT токенов</returns>
		[AllowAnonymous]
		[Route("Login")]
		[HttpPost]
		public async Task<IActionResult> Login([FromBody] LoginRequest request)
		{
			var user = await _userManager.GetItem(request);

			if (user == null)
			{
				return Unauthorized();
			}

			var loginResponse = await _loginManager.Authenticate(user);

			return Ok(loginResponse);
		}

		/// <summary>Ообновление пары JWT токенов</summary>
		/// <param name="request">Запрос содержащий Refresh JWT токен</param>
		/// <returns>Новая пара Access/Refresh JWT токенов</returns>
		[AllowAnonymous]
		[Route("Refresh")]
		[HttpPost]
		public async Task<IActionResult> Refresh([FromBody] RefreshRequest request)
		{
			var loginResponse = new LoginResponse();
			try
			{
				loginResponse = await _loginManager.Refresh(request);
			}
			catch(ArgumentException e)
			{
				return BadRequest(e.Message);
			}

			return Ok(loginResponse);
		}
	}
}
