using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IProductService _productService;
		private readonly IMapper _mapper;

		public ProductsController(IProductService productService, IMapper mapper)
		{
			_productService = productService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ProductList()
		{
			return Ok(_mapper.Map<List<ResultProductDto>>(_productService.TGetListAll()));
		}
		[HttpGet("ProductListWithCategory")]
		public IActionResult ProductListWithCategory()
		{
			var value = _mapper.Map<List<ResultProductWithCategory>>(_productService.TGetProductsWithCategories());			
			return Ok(value);
		}
		
		[HttpGet("ProductPriceAvg")]
		public IActionResult ProductPriceAvg()
		{
			return Ok(_productService.TProductPriceAvg());
		}
		
		[HttpGet("ProductNameByMaxPrice")]
		public IActionResult ProductNameByMaxPrice()
		{
			return Ok(_productService.TProductNameByMaxPrice());
		}
		[HttpGet("ProductNameByMinPrice")]
		public IActionResult ProductNameByMinPrice()
		{
			return Ok(_productService.TProductNameByMinPrice());
		}
		
		[HttpGet("ProductAvgPriceByHamburger")]
		public IActionResult ProductAvgPriceByHamburger()
		{
			return Ok(_productService.TProductAvgPriceByHamburger());
		}
		[HttpPost]
		public IActionResult ProductCreate(CreateProductDto createProductDto)
		{
			var value = _mapper.Map<Product>(createProductDto);
			_productService.TAdd(value);
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult ProductDelete(int id)
		{
			var value = _productService.TGetByID(id);
			_productService.TDelete(value);
			return Ok();
		}
		[HttpPut]
		public IActionResult ProductUpdate(UpdateProductDto updateProductDto)
		{
			var value = _mapper.Map<Product>(updateProductDto);
			_productService.TUpdate(value);
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult ProductGet(int id)
		{
			var value = _productService.TGetByID(id);
			return Ok(_mapper.Map<GetProductDto>(value));
		}

		[HttpGet("ProductCount")]
		public IActionResult ProductCount()
		{
			return Ok(_productService.TProductCount());
		}

		[HttpGet("ProductCountByCategoryNameBurger")]
		public IActionResult ProductCountByCategoryNameBurger()
		{
			return Ok(_productService.TProductCountByCategoryNameBurger());
		}

		[HttpGet("ProductCountByCategoryNameDrink")]
		public IActionResult ProductCountByCategoryNameDrink()
		{
			return Ok(_productService.TProductCountByCategoryNameDrink());
		}

		[HttpGet("ChangeProductStatusToFalse/{id}")]
		public IActionResult ChangeProductStatusToFalse(int id)
		{
			_productService.TChangeProductStatusToFalse(id);
			return Ok();
		}
		[HttpGet("ChangeProductStatusToTrue/{id}")]
		public IActionResult ChangeProductStatusToTrue(int id)
		{
			_productService.TChangeProductStatusToTrue(id);
			return Ok();
		}
		
		[HttpGet("GetListStatusByTrue")]
		public IActionResult GetListStatusByTrue()
		{	
			return Ok(_productService.TGetListStatusByTrue());
		}
		
		[HttpGet("GetLast9Products")]
		public IActionResult GetLast9Products()
		{
			return Ok(_productService.TGetLast9Products());
		}
	}
}
