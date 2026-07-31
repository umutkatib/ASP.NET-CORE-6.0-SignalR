using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.CategoryDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
		private readonly IMapper _mapper;

		public CategoriesController(ICategoryService categoryService, IMapper mapper)
		{
			_categoryService = categoryService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult CategoryList()
		{
			var values = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
			return Ok(values);
		}
		[HttpPost]
		public IActionResult CategoryCreate(CreateCategoryDto categoryDto)
		{
			_categoryService.TAdd(new Category()
			{
				CategoryName = categoryDto.CategoryName,
				CategoryStatus = true
			});
			return Ok();
		}
		[HttpDelete]
		public IActionResult CategoryDelete(int id)
		{
			var value = _categoryService.TGetByID(id);
			_categoryService.TDelete(value);
			return Ok();
		}
		[HttpPut]
		public IActionResult CategoryUpdate(UpdateCategoryDto updateCategoryDto)
		{
			_categoryService.TUpdate(new Category()
			{
				CategoryID = updateCategoryDto.CategoryID,
				CategoryName = updateCategoryDto.CategoryName,
				CategoryStatus = updateCategoryDto.CategoryStatus
			});
			return Ok();
		}
		[HttpGet("CategoryGet")]
		public IActionResult CategoryGet(int id)
		{
			var value = _categoryService.TGetByID(id);
			return Ok(value);
		}
	}
}
