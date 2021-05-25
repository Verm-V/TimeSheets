﻿using Microsoft.AspNetCore.Http;
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
	public class InvoicesController : ControllerBase
	{
		private readonly IInvoiceManager _manager;

		public InvoicesController(IInvoiceManager manager)
		{
			_manager = manager;
		}

		/// <summary>Получение информации о счете по его Id</summary>
		/// <param name="id">Id счета</param>
		/// <returns>Инорфмация о счете</returns>
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var result = await _manager.GetItem(id);
			return Ok(result);
		}

		/// <summary>Получение информации о нескольких счетах</summary>
		/// <returns>Коллекция содержащая информацию о счетах</returns>
		[HttpGet]
		public async Task<IActionResult> GetItems()
		{
			var result = await _manager.GetItems();
			return Ok(result);
		}

		/// <summary>Создание нового счета</summary>
		/// <param name="request">Закпрос на создание счета</param>
		/// <returns>Id созданного счета</returns>
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] InvoiceRequest request)
		{
			var id = await _manager.Create(request);
			return Ok(id);
		}

		/// <summary>Изменение существующего счета</summary>
		/// <param name="id">Id изменяемого счета</param>
		/// <param name="request">Запрос на изменение счета</param>
		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] InvoiceRequest request)
		{
			await _manager.Update(id, request);
			return Ok();

		}

		/// <summary>Удаление счета</summary>
		/// <param name="id">Id удаляемого счета</param>
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			await _manager.Delete(id);
			return Ok();
		}
	}
}
