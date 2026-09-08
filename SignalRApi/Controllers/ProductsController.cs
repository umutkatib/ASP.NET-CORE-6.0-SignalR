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
			var values = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
			return Ok(values);
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
			_productService.TAdd(new Product()
			{
				CategoryID = createProductDto.CategoryID,
				ProductName = createProductDto.ProductName,
				ProductPrice = createProductDto.ProductPrice,
				ProductDescription = createProductDto.ProductDescription,
				ProductImageURl = createProductDto.ProductImageURl,
				ProductStatus = true
			});
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
			_productService.TUpdate(new Product()
			{
				CategoryID=updateProductDto.CategoryID,
				ProductID = updateProductDto.ProductID,
				ProductName = updateProductDto.ProductName,
				ProductPrice = updateProductDto.ProductPrice,
				ProductDescription = updateProductDto.ProductDescription,
				ProductImageURl = updateProductDto.ProductImageURl,
				ProductStatus = updateProductDto.ProductStatus
			});
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult ProductGet(int id)
		{
			var value = _productService.TGetByID(id);
			return Ok(value);
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
	}
}
