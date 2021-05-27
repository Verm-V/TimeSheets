using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheets.Domain.Interfaces;
using TimeSheets.Models.Dto.Requests;
using TimeSheets.Infrastructure.Constants;

namespace TimeSheets.Controllers
{
	/// <summary>Работа с карточками учета времени</summary>
	[Route("api/[controller]")]
	[ApiController]
	public class SheetsController : ControllerBase
	{
		private readonly ISheetManager _sheetManager;
		private readonly IContractManager _contractManager;

		public SheetsController(ISheetManager sheetManager, IContractManager contractManager)
		{
			_sheetManager = sheetManager;
			_contractManager = contractManager;
		}

		/// <summary>Получение информации по карточке учета времени по ее Id</summary>
		/// <param name="id">Id карточки учета времени</param>
		/// <returns>Информация о карточке учата времени</returns>
		[Authorize(Roles = "admin, user")]
		[HttpGet("{id}")]
		public async Task<IActionResult> Get([FromRoute] Guid id)
		{
			var result = await _sheetManager.GetItem(id);
			return Ok(result);
		}

		/// <summary>Получение информации о нескольких карточках учета времени</summary>
		/// <returns>Коллекция содержащая информацию о карточках</returns>
		[Authorize(Roles = "admin, user")]
		[HttpGet]
		public async Task<IActionResult> GetItems()
		{
			var result = await _sheetManager.GetItems();
			return Ok(result);
		}

		/// <summary>Создание новой карточки учета времени</summary>
		/// <param name="request">Запрос на создание новой карточки учета времени</param>
		/// <returns>Id созданной карточки</returns>
		[Authorize(Roles = "admin, user")]
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] SheetRequest request)
		{
			var isAllowedToCreate = await _contractManager.CheckContractIsActive(request.ContractId);
			
			if(isAllowedToCreate != null && !(bool)isAllowedToCreate)
			{
				return BadRequest($"Contract {request.ContractId} is not active or not found.");
			}  

			var id = await _sheetManager.Create(request);
			return Ok(id);
		}

		/// <summary>Изменение существующей карточки учета времени</summary>
		/// <param name="id">Id изменяемой карточки</param>
		/// <param name="request">Запрос на изменение карточки</param>
		[Authorize(Roles = "admin")]
		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] SheetRequest request)
		{
			await _sheetManager.Update(id, request);
			return Ok();
		}

		/// <summary>Удаление карточки</summary>
		/// <param name="id">Id удаляемой карточки</param>
		[Authorize(Roles = "admin")]
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			await _sheetManager.Delete(id);
			return Ok();
		}


	}
}
