using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.TestimonialDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialsController : ControllerBase
	{
		private readonly ITestimonialService _testimonialService;
		private readonly IMapper _mapper;

		public TestimonialsController(ITestimonialService testimonialService, IMapper mapper)
		{
			_testimonialService = testimonialService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult TestimonialList()
		{
			var values = _mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll());
			return Ok(values);
		}
		[HttpPost]
		public IActionResult TestimonialCreate(CreateTestimonialDto createTestimonialDto)
		{
			_testimonialService.TAdd(new Testimonial()
			{
				TestimonialName = createTestimonialDto.TestimonialName,
				TestimonialTitle = createTestimonialDto.TestimonialTitle,
				TestimonialComment = createTestimonialDto.TestimonialComment,
				TestimonialImageUrl = createTestimonialDto.TestimonialImageUrl,
				TestimonialStatus = true
			});
			return Ok();
		}
		[HttpDelete]
		public IActionResult TestimonialDelete(int id)
		{
			var value = _testimonialService.TGetByID(id);
			_testimonialService.TDelete(value);
			return Ok();
		}
		[HttpPut]
		public IActionResult TestimonialUpdate(UpdateTestimonialDto updateTestimonialDto)
		{
			_testimonialService.TUpdate(new Testimonial()
			{
				TestimonialID = updateTestimonialDto.TestimonialID,
				TestimonialName = updateTestimonialDto.TestimonialName,
				TestimonialTitle = updateTestimonialDto.TestimonialTitle,
				TestimonialComment = updateTestimonialDto.TestimonialComment,
				TestimonialImageUrl = updateTestimonialDto.TestimonialImageUrl,
				TestimonialStatus = updateTestimonialDto.TestimonialStatus
			});
			return Ok();
		}
		[HttpGet("TestimonialGet")]
		public IActionResult TestimonialGet(int id)
		{
			var value = _testimonialService.TGetByID(id);
			return Ok(value);
		}
	}
}
