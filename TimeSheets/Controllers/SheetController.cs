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
	public class SheetController : ControllerBase
	{
		private readonly ISheetManager _sheetManager;

		public SheetController(ISheetManager sheetManager)
		{
			_sheetManager = sheetManager;
		}

		[HttpGet]
		public IActionResult Get(Guid id)
		{
			var result = _sheetManager.GetItem(id);
			return Ok(result);
		}

		[HttpPost]
		public IActionResult Create([FromBody] SheetCreateRequest sheet)
		{
			var id = _sheetManager.Create(sheet);
			return Ok(id);
		}
	}
}
