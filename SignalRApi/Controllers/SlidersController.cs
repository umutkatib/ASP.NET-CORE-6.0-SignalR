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
			var values = _mapper.Map<List<ResultSliderDto>>(_sliderService.TGetListAll());
			return Ok(values);
		}
		[HttpPost]
		public IActionResult SliderCreate(CreateSliderDto createSliderDto)
		{
			_sliderService.TAdd(new Slider()
			{
				SliderTitle1 = createSliderDto.SliderTitle1,
				SliderDescription1 = createSliderDto.SliderDescription1,
				SliderTitle2 = createSliderDto.SliderTitle2,
				SliderDescription2 = createSliderDto.SliderDescription2,
				SliderTitle3 = createSliderDto.SliderTitle3,
				SliderDescription3 = createSliderDto.SliderDescription3,
			});
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
			_sliderService.TUpdate(new Slider()
			{
				SliderID = updateSliderDto.SliderID,
				SliderTitle1 = updateSliderDto.SliderTitle1,
				SliderDescription1 = updateSliderDto.SliderDescription1,
				SliderTitle2 = updateSliderDto.SliderTitle2,
				SliderDescription2 = updateSliderDto.SliderDescription2,
				SliderTitle3 = updateSliderDto.SliderTitle3,
				SliderDescription3 = updateSliderDto.SliderDescription3,
			});
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult SliderGet(int id)
		{
			var value = _sliderService.TGetByID(id);
			return Ok(value);
		}
	}
}
