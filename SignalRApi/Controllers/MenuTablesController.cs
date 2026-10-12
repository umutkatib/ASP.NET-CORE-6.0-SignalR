using AutoMapper;
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
		private readonly IMapper _mapper;

		public MenuTablesController(IMenuTableService menuTableService, IMapper mapper)
		{
			_menuTableService = menuTableService;
			_mapper = mapper;
		}

		[HttpGet("MenuTableCount")]
		public IActionResult MenuTableCount()
		{
			return Ok(_menuTableService.TMenuTableCount());
		}

		[HttpGet]
		public IActionResult MenuTableList()
		{
			return Ok(_mapper.Map<List<ResultMenuTableDto>>(_menuTableService.TGetListAll()));
		}

		[HttpPost]
		public IActionResult MenuTableCreate(CreateMenuTableDto createMenuTableDto)
		{
			createMenuTableDto.MenuTableStatus = false;
			var value = _mapper.Map<MenuTable>(createMenuTableDto);
			_menuTableService.TAdd(value);
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
			var value = _mapper.Map<MenuTable>(updateMenuTableDto);
			_menuTableService.TAdd(value);
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult MenuTableGet(int id)
		{
			var value = _menuTableService.TGetByID(id);
			return Ok(_mapper.Map<GetMenuTableDto>(value));
		}
	}
}
