namespace SignalRWebUI.Dtos.NotificationDtos
{
	public class CreateNotificationDto
	{
		public string NotificationIcon { get; set; }
		public string NotificationType { get; set; }
		public string NotificationDescription { get; set; }
		public bool NotificationStatus { get; set; }
	}
}
