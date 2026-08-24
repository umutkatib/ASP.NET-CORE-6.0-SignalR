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
			var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
			return Ok(values);
		}
		[HttpPost]
		public IActionResult SocialMediaCreate(CreateSocialMediaDto createSocialMediaDto)
		{
			_socialMediaService.TAdd(new SocialMedia()
			{
				SocialMediaTitle = createSocialMediaDto.SocialMediaTitle,
				SocialMediaIcon = createSocialMediaDto.SocialMediaIcon,
				SocialMediaUrl = createSocialMediaDto.SocialMediaUrl,
			});
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
			_socialMediaService.TUpdate(new SocialMedia()
			{
				SocialMediaID = updateSocialMediaDto.SocialMediaID,
				SocialMediaTitle = updateSocialMediaDto.SocialMediaTitle,
				SocialMediaIcon = updateSocialMediaDto.SocialMediaIcon,
				SocialMediaUrl = updateSocialMediaDto.SocialMediaUrl,
			});
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult SocialMediaGet(int id)
		{
			var value = _socialMediaService.TGetByID(id);
			return Ok(value);
		}
	}
}
