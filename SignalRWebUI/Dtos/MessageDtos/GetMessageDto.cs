namespace SignalRWebUI.Dtos.MessageDtos
{
	public class GetMessageDto
	{
		public int MessageID { get; set; }
		public string MessageNameSurname { get; set; }
		public string MessageMail { get; set; }
		public string MessagePhone { get; set; }
		public string MessageSubject { get; set; }
		public string MessageContent { get; set; }
		public DateTime MessageSendDate { get; set; }
		public bool MessageStatus { get; set; }
	}
}
