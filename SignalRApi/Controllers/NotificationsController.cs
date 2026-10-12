using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationsController : ControllerBase
	{
		private readonly INotificationService _notificationService;
		private readonly IMapper _mapper;

		public NotificationsController(INotificationService notificationService, IMapper mapper)
		{
			_notificationService = notificationService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult NotificationList()
		{
			return Ok(_mapper.Map<List<ResultNotificationDto>>(_notificationService.TGetListAll()));
		}

		[HttpPost]
		public IActionResult NotificationCreate(CreateNotificationDto createNotificationDto)
		{
			createNotificationDto.NotificationStatus = false;
			createNotificationDto.NotificationDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			var value = _mapper.Map<Notification>(createNotificationDto);
			_notificationService.TAdd(value);
			return Ok();
		}

		[HttpDelete]
		public IActionResult NotificationDelete(int id)
		{
			var value = _notificationService.TGetByID(id);
			_notificationService.TDelete(value);
			return Ok();
		}

		[HttpGet("{id}")]
		public IActionResult NotificationGet(int id)
		{
			var value = _notificationService.TGetByID(id);
			return Ok(_mapper.Map<GetNotificationDto>(value));
		}

		[HttpPut]
		public IActionResult NotificationCreate(UpdateNotificationDto updateNotificationDto)
		{
			var value = _mapper.Map<Notification>(updateNotificationDto);
			_notificationService.TUpdate(value);
			return Ok();
		}

		[HttpGet("NotificationCountByStatusFalse")]
		public IActionResult NotificationCountByStatusFalse()
		{
			return Ok(_notificationService.TNotificationCountByStatusFalse());
		}

		[HttpGet("GetAllNotificationByFalse")]
		public IActionResult GetAllNotificationByFalse()
		{
			return Ok(_notificationService.TGetAllNotificationByFalse());
		}

		[HttpGet("NotificationStatusChangeToTrue/{id}")]
		public IActionResult NotificationStatusChangeToTrue(int id)
		{
			_notificationService.TNotificationStatusChangeToTrue(id);
			return Ok();
		}
		[HttpGet("NotificationStatusChangeToFalse/{id}")]
		public IActionResult NotificationStatusChangeToFalse(int id)
		{
			_notificationService.TNotificationStatusChangeToFalse(id);
			return Ok();
		}
	}
}
