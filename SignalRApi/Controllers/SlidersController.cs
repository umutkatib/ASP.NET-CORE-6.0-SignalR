using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SliderDto;

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
	}
}
