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
using System.Diagnostics.CodeAnalysis;

namespace TimeSheets.Controllers
{
	/// <summary>Работа с карточками учета времени</summary>
	[ExcludeFromCodeCoverage]
	public class SheetsController : TimeSheetBaseController
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
		public async Task<IActionResult> Create([FromBody] SheetCreateRequest request)
		{
			var isAllowedToCreate = await _contractManager.CheckContractIsActive(request.ContractId);
			
			if(isAllowedToCreate != null && !(bool)isAllowedToCreate)
			{
				return BadRequest($"Contract {request.ContractId} is not active or not found.");
			}  

			var id = await _sheetManager.Create(request);
			return Ok(id);
		}

		/// <summary>Подтверждение карточки</summary>
		[Authorize(Roles = "admin")]
		[HttpPut("{id}")]
		public async Task<IActionResult> Approve([FromRoute] Guid id)
		{
			await _sheetManager.Approve(id);
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
