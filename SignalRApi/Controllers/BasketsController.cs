using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BasketsController : ControllerBase
	{
		private readonly IBasketService _basketService;

		public BasketsController(IBasketService basketService)
		{
			_basketService = basketService;
		}

		[HttpGet]
		public IActionResult GetBasketByMenuTableID(int id)
		{
			var values = _basketService.TGetBasketByMenuTableNumber(id);
			return Ok(values);
		}

		[HttpGet("BasketListByMenuTableWithProductName")]
		public IActionResult BasketListByMenuTableWithProductName(int id)
		{
			using var context = new SignalRContext();
			var values = context.Baskets.Include(x => x.Product)
				.Where(y => y.MenuTableID == id)
				.Select(z => new ResultBasketListWithProducts
				{
					BasketID = z.BasketID,
					MenuTableID = z.MenuTableID,
					ProductID = z.ProductID,
					BasketCount = z.BasketCount,
					BasketPrice = z.BasketPrice,
					BasketTotalPrice = z.BasketTotalPrice,
					BasketProductName = z.Product.ProductName,
				}).ToList();
			return Ok(values);
		}

		[HttpPost]
		public IActionResult BasketCreate(CreateBasketDto createBasketDto)
		{
			using var context = new SignalRContext();
			_basketService.TAdd(new Basket()
			{
				ProductID = createBasketDto.ProductID,
				BasketCount = 1,
				MenuTableID = createBasketDto.MenuTableID,
				BasketPrice = context.Products.
					Where(x => x.ProductID == createBasketDto.ProductID).
					Select(y => y.ProductPrice)
					.FirstOrDefault(),
				BasketTotalPrice = createBasketDto.BasketTotalPrice,

			});
			return Ok();
		}

		[HttpDelete("{id}")]
		public IActionResult BasketDelete(int id)
		{
			var value = _basketService.TGetByID(id);
			_basketService.TDelete(value);
			return Ok();
		}
	}
}
