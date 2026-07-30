using AutoMapper;
using SignalR.DtoLayer.HourDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Mapping
{
	public class HourMapper : Profile
	{
		public HourMapper()
		{
			CreateMap<Hour, ResultHourDto>().ReverseMap();
			CreateMap<Hour, CreateHourDto>().ReverseMap();
			CreateMap<Hour, UpdateHourDto>().ReverseMap();
			CreateMap<Hour, GetHourDto>().ReverseMap();
		}
	}
}
