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
	public class ContractsController : ControllerBase
	{
		private readonly IContractManager _manager;

		public ContractsController(IContractManager manager)
		{
			_manager = manager;
		}

		/// <summary>Получение информации о контракте по его Id</summary>
		/// <param name="id">Id контракта</param>
		/// <returns>Инорфмация о контракте</returns>
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var result = await _manager.GetItem(id);
			return Ok(result);
		}

		/// <summary>Получение информации о нескольких контрактах</summary>
		/// <returns>Коллекция содержащая информацию о контрактах</returns>
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
		public async Task<IActionResult> Create([FromBody] ContractRequest request)
		{
			var id = await _manager.Create(request);
			return Ok(id);
		}

		/// <summary>Изменение существующего контракта</summary>
		/// <param name="id">Id изменяемого контракта</param>
		/// <param name="request">Запрос на изменение контракта</param>
		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] ContractRequest request)
		{
			await _manager.Update(id, request);
			return Ok();

		}

		/// <summary>Удаление контракта</summary>
		/// <param name="id">Id удаляемого конракта</param>
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			await _manager.Delete(id);
			return Ok();
		}
	}
}
