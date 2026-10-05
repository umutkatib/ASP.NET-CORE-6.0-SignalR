using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MenuTableDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MenuTablesController : ControllerBase
	{
		private readonly IMenuTableService _menuTableService;

		public MenuTablesController(IMenuTableService menuTableService)
		{
			_menuTableService = menuTableService;
		}

		[HttpGet("MenuTableCount")]
		public IActionResult MenuTableCount()
		{
			return Ok(_menuTableService.TMenuTableCount());
		}

		[HttpGet]
		public IActionResult MenuTableList()
		{
			return Ok(_menuTableService.TGetListAll());
		}

		[HttpPost]
		public IActionResult MenuTableCreate(CreateMenuTableDto createMenuTableDto)
		{
			_menuTableService.TAdd(new MenuTable()
			{
				MenuTableName = createMenuTableDto.MenuTableName,
				MenuTableStatus = false,
			});
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult MenuTableDelete(int id)
		{
			var value = _menuTableService.TGetByID(id);
			_menuTableService.TDelete(value);
			return Ok();
		}

		[HttpPut]
		public IActionResult MenuTableUpdate(UpdateMenuTableDto updateMenuTableDto)
		{
			_menuTableService.TUpdate(new MenuTable()
			{
				MenuTableID = updateMenuTableDto.MenuTableID,
				MenuTableName = updateMenuTableDto.MenuTableName,
				MenuTableStatus = updateMenuTableDto.MenuTableStatus,
			});
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult MenuTableGet(int id)
		{
			return Ok(_menuTableService.TGetByID(id));
		}
	}
}
