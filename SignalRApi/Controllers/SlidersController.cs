using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SliderDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SlidersController : ControllerBase
	{
		private readonly ISliderService _sliderService;
		private readonly IMapper _mapper;

		public SlidersController(ISliderService sliderService, IMapper mapper)
		{
			_sliderService = sliderService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult SliderList()
		{
			return Ok(_mapper.Map<List<ResultSliderDto>>(_sliderService.TGetListAll()));
		}
		[HttpPost]
		public IActionResult SliderCreate(CreateSliderDto createSliderDto)
		{
			var value = _mapper.Map<Slider>(createSliderDto);
			_sliderService.TAdd(value);
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult SliderDelete(int id)
		{
			var value = _sliderService.TGetByID(id);
			_sliderService.TDelete(value);
			return Ok();
		}
		[HttpPut]
		public IActionResult SliderUpdate(UpdateSliderDto updateSliderDto)
		{
			var value = _mapper.Map<Slider>(updateSliderDto);
			_sliderService.TUpdate(value);
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult SliderGet(int id)
		{
			var value = _sliderService.TGetByID(id);
			return Ok(_mapper.Map<GetSliderDto>(value));
		}
	}
}
