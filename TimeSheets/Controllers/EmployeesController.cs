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
	public class EmployeesController : ControllerBase
	{
		private readonly IEmployeeManager _manager;

		public EmployeesController(IEmployeeManager manager)
		{
			_manager = manager;
		}

		/// <summary>Получение информации о сотруднике по его Id</summary>
		/// <param name="id">Id сотрудника</param>
		/// <returns>Инорфмация о сотруднике</returns>
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var result = await _manager.GetItem(id);
			return Ok(result);
		}

		/// <summary>Получение информации о нескольких сотрудниках</summary>
		/// <returns>Коллекция содержащая информацию о сотрудниках</returns>
		[HttpGet]
		public async Task<IActionResult> GetItems()
		{
			var result = await _manager.GetItems();
			return Ok(result);
		}

		/// <summary>Создание нового сотрудника</summary>
		/// <param name="request">Закпрос на создание сотрудника</param>
		/// <returns>Id созданного сотрудника</returns>
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] EmployeeRequest request)
		{
			var id = await _manager.Create(request);
			return Ok(id);
		}

		/// <summary>Изменение существующего сотрудника</summary>
		/// <param name="id">Id изменяемого сотрудника</param>
		/// <param name="request">Запрос на изменение сотрудника</param>
		[HttpPut("{id}")]
		public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] EmployeeRequest request)
		{
			await _manager.Update(id, request);
			return Ok();

		}

		/// <summary>Удаление сотрудника</summary>
		/// <param name="id">Id удаляемого сотрудника</param>
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete([FromRoute] Guid id)
		{
			await _manager.Delete(id);
			return Ok();
		}
	}
}
