using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.HourDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HoursController : ControllerBase
	{
		private readonly IHourService _hourService;
		private readonly IMapper _mapper;

		public HoursController(IHourService hourService, IMapper mapper)
		{
			_hourService = hourService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult HourList()
		{
			var values = _mapper.Map<List<ResultHourDto>>(_hourService.TGetListAll());
			return Ok(values);
		}
		[HttpPost]
		public IActionResult HourCreate(CreateHourDto createHourDto)
		{
			_hourService.TAdd(new Hour()
			{
				HourTitle = createHourDto.HourTitle,
				HourDescription = createHourDto.HourDescription,
				HourDay = createHourDto.HourDay,
			});
			return Ok();
		}
		[HttpDelete]
		public IActionResult HourDelete(int id)
		{
			var value = _hourService.TGetByID(id);
			_hourService.TDelete(value);
			return Ok();
		}
		[HttpPut]
		public IActionResult HourUpdate(UpdateHourDto updateHourDto)
		{
			_hourService.TUpdate(new Hour()
			{
				HourID = updateHourDto.HourID,
				HourTitle = updateHourDto.HourTitle,
				HourDescription = updateHourDto.HourDescription,
				HourDay = updateHourDto.HourDay,
			});
			return Ok();
		}
		[HttpGet("HourGet")]
		public IActionResult HourGet(int id)
		{
			var value = _hourService.TGetByID(id);
			return Ok(value);
		}
	}
}
