using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SocialMediasController : ControllerBase
	{
		private readonly ISocialMediaService _socialMediaService;
		private readonly IMapper _mapper;

		public SocialMediasController(ISocialMediaService socialMediaService, IMapper mapper)
		{
			_socialMediaService = socialMediaService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult SocialMediaList()
		{
			return Ok(_mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll()));
		}
		[HttpPost]
		public IActionResult SocialMediaCreate(CreateSocialMediaDto createSocialMediaDto)
		{
			var value = _mapper.Map<SocialMedia>(createSocialMediaDto);
			_socialMediaService.TAdd(value);
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult SocialMediaDelete(int id)
		{
			var value = _socialMediaService.TGetByID(id);
			_socialMediaService.TDelete(value);
			return Ok();
		}
		[HttpPut]
		public IActionResult SocialMediaUpdate(UpdateSocialMediaDto updateSocialMediaDto)
		{
			var value = _mapper.Map<SocialMedia>(updateSocialMediaDto);
			_socialMediaService.TUpdate(value);
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult SocialMediaGet(int id)
		{
			var value = _socialMediaService.TGetByID(id);
			return Ok(_mapper.Map<GetSocialMediaDto>(value));
		}
	}
}
