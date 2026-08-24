namespace SignalRWebUI.Dtos.ContactDtos
{
	public class UpdateContactDto
	{
		public int ContactID { get; set; }
		public string ContactLocation { get; set; }
		public string ContactPhoneNumber { get; set; }
		public string ContactMail { get; set; }
		public string ContactFooterDescription { get; set; }
	}
}
