using AutoMapper;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class SocialMediaMapper : Profile
	{
		public SocialMediaMapper()
		{
			CreateMap<SocialMedia, ResultSocialMediaDto>().ReverseMap();
			CreateMap<SocialMedia, CreateSocialMediaDto>().ReverseMap();
			CreateMap<SocialMedia, UpdateSocialMediaDto>().ReverseMap();
			CreateMap<SocialMedia, GetSocialMediaDto>().ReverseMap();
		}
	}
}
