using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Dto.Requests;

namespace TimeSheets.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserManager _manager;

		public UserController(IUserManager manager)
		{
			_manager = manager;
		}

		/// <summary>Получение информации о пользователе по его Id</summary>
		/// <param name="id">Id пользователя</param>
		/// <returns>Инорфмация о пользователе</returns>
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var result = await _manager.GetItem(id);
			return Ok(result);
		}

		/// <summary>Получение информации о нескольких пользователях</summary>
		/// <returns>Коллекция содержащая информацию о пользователях</returns>
		[HttpGet]
		public async Task<IActionResult> GetItems()
		{
			var result = await _manager.GetItems();
			return Ok(result);
		}

		/// <summary>Создание нового контракта</summary>
		/// <param name="request">Закпрос на создание контракта</param>
		/// <returns>Id созданного контракта</returns>
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] UserRequest request)
		{
			var id = await _manager.Create(request);
			return Ok(id);
		}

		/// <summary>Изменение существующего контракта</summary>
		/// <param name="id">Id изменяемого контракта</param>
		/// <param name="request">Запрос на изменение контракта</param>
		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UserRequest request)
		{
			await _manager.Update(id, request);
			return Ok();

		}

		/// <summary>Удаляет контракт</summary>
		/// <param name="id">Id удаляемого конракта</param>
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			await _manager.Delete(id);
			return Ok();
		}
	}
}
