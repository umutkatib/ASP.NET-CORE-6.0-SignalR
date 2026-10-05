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

		public NotificationsController(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}

		[HttpGet]
		public IActionResult NotificationList()
		{
			return Ok(_notificationService.TGetListAll());
		}

		[HttpPost]
		public IActionResult NotificationCreate(CreateNotificationDto createNotificationDto)
		{
			_notificationService.TAdd(new Notification()
			{
				NotificationType = createNotificationDto.NotificationType,
				NotificationDescription = createNotificationDto.NotificationDescription,
				NotificationIcon = createNotificationDto.NotificationIcon,
				NotificationStatus = false,
				NotificationDate = Convert.ToDateTime(DateTime.Now.ToShortDateString())
			});
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
			return Ok(_notificationService.TGetByID(id));
		}

		[HttpPut]
		public IActionResult NotificationCreate(UpdateNotificationDto updateNotificationDto)
		{
			Notification notification = new Notification()
			{
				NotificationID = updateNotificationDto.NotificationID,
				NotificationType = updateNotificationDto.NotificationType,
				NotificationDescription = updateNotificationDto.NotificationDescription,
				NotificationIcon = updateNotificationDto.NotificationIcon,
				NotificationStatus = updateNotificationDto.NotificationStatus,
				NotificationDate = updateNotificationDto.NotificationDate,
			};
			_notificationService.TUpdate(notification);
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
