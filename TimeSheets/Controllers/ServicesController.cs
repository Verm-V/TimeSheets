﻿using Microsoft.AspNetCore.Authorization;
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
	/// <summary>Работа с услугами оказываемыми клиентам</summary>
	[ApiExplorerSettings(GroupName = "v2")]
	public class ServicesController : TimeSheetBaseController
	{
		private readonly IServiceManager _manager;

		public ServicesController(IServiceManager manager)
		{
			_manager = manager;
		}

		/// <summary>Получение информации об услуге по ее Id</summary>
		/// <param name="id">Id услуги</param>
		/// <returns>Инорфмация об услуге</returns>
		[Authorize(Roles = "admin, user, client")]
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var result = await _manager.GetItem(id);
			return Ok(result);
		}

		/// <summary>Получение информации о нескольких услугах</summary>
		/// <returns>Коллекция содержащая информацию об услугах</returns>
		[Authorize(Roles = "admin, user, client")]
		[HttpGet]
		public async Task<IActionResult> GetItems()
		{
			var result = await _manager.GetItems();
			return Ok(result);
		}

		/// <summary>Создание нового услуги</summary>
		/// <param name="request">Закпрос на создание услуги</param>
		/// <returns>Id созданной услуги</returns>
		[Authorize(Roles = "admin, user")]
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] ServiceRequest request)
		{
			var id = await _manager.Create(request);
			return Ok(id);
		}

		/// <summary>Изменение существующй услуги</summary>
		/// <param name="id">Id изменяемой услуги</param>
		/// <param name="request">Запрос на изменение услуги</param>
		[Authorize(Roles = "admin")]
		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ServiceRequest request)
		{
			await _manager.Update(id, request);
			return Ok();

		}

		/// <summary>Удаление услуги</summary>
		/// <param name="id">Id удаляемой услуги</param>
		[Authorize(Roles = "admin")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			await _manager.Delete(id);
			return Ok();
		}
	}
}
