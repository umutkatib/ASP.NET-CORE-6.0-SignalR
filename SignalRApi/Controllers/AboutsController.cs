using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutsController : ControllerBase
	{
		private readonly IAboutService _aboutService;
		private readonly IMapper _mapper;

		public AboutsController(IAboutService aboutService, IMapper mapper)
		{
			_aboutService = aboutService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult AboutList()
		{
			var values = _mapper.Map<List<ResultAboutDto>>(_aboutService.TGetListAll());
			return Ok(values);
		}
		[HttpPost]
		public IActionResult AboutCreate(CreateAboutDto createAboutDto)
		{
			_aboutService.TAdd(new About()
			{
				AboutTitle = createAboutDto.AboutTitle,
				AboutDescription = createAboutDto.AboutDescription,
				AboutImageUrl = createAboutDto.AboutImageUrl,
			});
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult AboutDelete(int id)
		{
			var value = _aboutService.TGetByID(id);
			_aboutService.TDelete(value);
			return Ok();
		}
		[HttpPut]
		public IActionResult AboutUpdate(UpdateAboutDto updateAboutDto)
		{
			_aboutService.TUpdate(new About()
			{
				AboutID = updateAboutDto.AboutID,
				AboutTitle = updateAboutDto.AboutTitle,
				AboutDescription = updateAboutDto.AboutDescription,
				AboutImageUrl = updateAboutDto.AboutImageUrl,
			});
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult AboutGet(int id)
		{
			var value = _aboutService.TGetByID(id);
			return Ok(value);
		}
	}
}
