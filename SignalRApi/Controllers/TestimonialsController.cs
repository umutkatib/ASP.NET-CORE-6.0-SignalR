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
			return Ok(_mapper.Map<List<ResultTestimonialDto>>(_testimonialService.TGetListAll()));
		}
		[HttpPost]
		public IActionResult TestimonialCreate(CreateTestimonialDto createTestimonialDto)
		{
			createTestimonialDto.TestimonialStatus = true;
			var value = _mapper.Map<Testimonial>(createTestimonialDto);
			_testimonialService.TAdd(value);
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult TestimonialDelete(int id)
		{
			var value = _testimonialService.TGetByID(id);
			_testimonialService.TDelete(value);
			return Ok();
		}
		[HttpPut]
		public IActionResult TestimonialUpdate(UpdateTestimonialDto updateTestimonialDto)
		{
			var value = _mapper.Map<Testimonial>(updateTestimonialDto);
			_testimonialService.TUpdate(value);
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult TestimonialGet(int id)
		{
			var value = _testimonialService.TGetByID(id);
			return Ok(_mapper.Map<GetTestimonialDto>(value));
		}

		[HttpGet("ChangeTestimonialStatusToFalse/{id}")]
		public IActionResult ChangeTestimonialStatusToFalse(int id)
		{
			_testimonialService.TChangeTestimonialStatusToFalse(id);
			return Ok();
		}
		[HttpGet("ChangeTestimonialStatusToTrue/{id}")]
		public IActionResult ChangeTestimonialStatusToTrue(int id)
		{
			_testimonialService.TChangeTestimonialStatusToTrue(id);
			return Ok();
		}
		
		[HttpGet("GetListStatusByTrue")]
		public IActionResult GetListStatusByTrue()
		{
			return Ok(_testimonialService.TGetListStatusByTrue());
		}


	}
}
