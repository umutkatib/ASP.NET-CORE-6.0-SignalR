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
			var values = _mapper.Map<List<ResultDiscountDto>>(_discountService.TGetListAll());
			return Ok(values);
		}
		[HttpPost]
		public IActionResult DiscountCreate(CreateDiscountDto createDiscountDto)
		{
			_discountService.TAdd(new Discount()
			{
				DiscountTitle = createDiscountDto.DiscountTitle,
				DiscountAmount = createDiscountDto.DiscountAmount,
				DiscountDescription = createDiscountDto.DiscountDescription,
				DiscountImageUrl = createDiscountDto.DiscountImageUrl,
			});
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
			_discountService.TUpdate(new Discount()
			{
				DiscountID = updateDiscountDto.DiscountID,
				DiscountTitle = updateDiscountDto.DiscountTitle,
				DiscountAmount = updateDiscountDto.DiscountAmount,
				DiscountDescription = updateDiscountDto.DiscountDescription,
				DiscountImageUrl = updateDiscountDto.DiscountImageUrl,
			});
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult DiscountGet(int id)
		{
			var value = _discountService.TGetByID(id);
			return Ok(value);
		}
	}
}
