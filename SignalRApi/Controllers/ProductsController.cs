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
		[HttpPost]
		public IActionResult ProductCreate(CreateProductDto createProductDto)
		{
			_productService.TAdd(new Product()
			{
				ProductName = createProductDto.ProductName,
				ProductPrice = createProductDto.ProductPrice,
				ProductDescription = createProductDto.ProductDescription,
				ProductImageURl = createProductDto.ProductImageURl,
				ProductStatus = true
			});
			return Ok();
		}
		[HttpDelete]
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
				ProductID = updateProductDto.ProductID,
				ProductName = updateProductDto.ProductName,
				ProductPrice = updateProductDto.ProductPrice,
				ProductDescription = updateProductDto.ProductDescription,
				ProductImageURl = updateProductDto.ProductImageURl,
				ProductStatus = updateProductDto.ProductStatus
			});
			return Ok();
		}
		[HttpGet("ProductGet")]
		public IActionResult ProductGet(int id)
		{
			var value = _productService.TGetByID(id);
			return Ok(value);
		}
	}
}
