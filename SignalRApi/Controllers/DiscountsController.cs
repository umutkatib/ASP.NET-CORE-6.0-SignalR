using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.DiscountDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DiscountsController : ControllerBase
	{
		private readonly IDiscountService _discountService;
		private readonly IMapper _mapper;

		public DiscountsController(IDiscountService discountService, IMapper mapper)
		{
			_discountService = discountService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult DiscountList()
		{
			return Ok(_mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll()));
		}
		[HttpPost]
		public IActionResult DiscountCreate(CreateDiscountDto createDiscountDto)
		{
			var value = _mapper.Map<Discount>(createDiscountDto);
			_discountService.TAdd(value);
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult DiscountDelete(int id)
		{
			var value = _discountService.TGetByID(id);
			_discountService.TDelete(value);
			return Ok();
		}
		[HttpPut]
		public IActionResult DiscountUpdate(UpdateDiscountDto updateDiscountDto)
		{
			var value = _mapper.Map<Discount>(updateDiscountDto);
			_discountService.TUpdate(value);
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult DiscountGet(int id)
		{
			var value = _discountService.TGetByID(id);
			return Ok(_mapper.Map<GetDiscountDto>(value));
		}
		[HttpGet("ChangeStatusToFalse/{id}")]
		public IActionResult ChangeStatusToFalse(int id)
		{
			_discountService.TChangeStatusToFalse(id);
			return Ok();
		}
		[HttpGet("ChangeStatusToTrue/{id}")]
		public IActionResult ChangeStatusToTrue(int id)
		{
			_discountService.TChangeStatusToTrue(id);
			return Ok();
		}
		
		[HttpGet("GetListStatusByTrue")]
		public IActionResult GetListStatusByTrue()
		{
			return Ok(_discountService.TGetListStatusByTrue());
		}
	}
}
