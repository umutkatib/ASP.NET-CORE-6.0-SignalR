namespace SignalR.DtoLayer.ContactDto
{
	public class UpdateContactDto
	{
		public int ContactID { get; set; }
		public string ContactLocation { get; set; }
		public string ContactPhoneNumber { get; set; }
		public string ContactMail { get; set; }
		public string ContactTitle { get; set; }
		public string ContactFooterDescription { get; set; }
		public string ContactOpenDays { get; set; }
		public string ContactOpenDescription { get; set; }
		public string ContactOpenHours { get; set; }
	}
}
