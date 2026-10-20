using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
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
		private readonly IValidator<CreateCategoryDto> _validatorForCreate;
		private readonly IValidator<UpdateCategoryDto> _validatorForUpdate;

		public CategoriesController(ICategoryService categoryService, IMapper mapper, IValidator<CreateCategoryDto> validatorForCreate, IValidator<UpdateCategoryDto> validatorForUpdate)
		{
			_categoryService = categoryService;
			_mapper = mapper;
			_validatorForCreate = validatorForCreate;
			_validatorForUpdate = validatorForUpdate;
		}

		[HttpGet]
		public IActionResult CategoryList()
		{
			return Ok(_mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll()));
		}
		[HttpPost]
		public IActionResult CategoryCreate(CreateCategoryDto createCategoryDto)
		{
			var validationResult = _validatorForCreate.Validate(createCategoryDto);
			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors);
			}
			var value = _mapper.Map<Category>(createCategoryDto);
			_categoryService.TAdd(value);
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult CategoryDelete(int id)
		{
			var value = _categoryService.TGetByID(id);
			_categoryService.TDelete(value);
			return Ok();
		}
		[HttpPut]
		public IActionResult CategoryUpdate(UpdateCategoryDto updateCategoryDto)
		{
			var validationResult = _validatorForUpdate.Validate(updateCategoryDto);
			if (!validationResult.IsValid)
			{
				return BadRequest(validationResult.Errors);
			}
			var value = _mapper.Map<Category>(updateCategoryDto);
			_categoryService.TUpdate(value);
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult CategoryGet(int id)
		{
			var value = _categoryService.TGetByID(id);
			return Ok(_mapper.Map<GetCategoryDto>(value));
		}

		[HttpGet("CategoryCount")]
		public IActionResult CategoryCount()
		{
			return Ok(_categoryService.TCategoryCount());
		}

		[HttpGet("ActiveCategoryCount")]
		public IActionResult ActiveCategoryCount()
		{
			return Ok(_categoryService.TActiveCategoryCount());
		}

		[HttpGet("PassiveCategoryCount")]
		public IActionResult PassiveCategoryCount()
		{
			return Ok(_categoryService.TPassiveCategoryCount());
		}
	}
}
