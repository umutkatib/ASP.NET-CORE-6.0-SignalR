using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessagesController : ControllerBase
	{
		private readonly IMessageService _messageService;

		public MessagesController(IMessageService messageService)
		{
			_messageService = messageService;
		}

		[HttpGet]
		public IActionResult MessageList()
		{
			return Ok(_messageService.TGetListAll());
		}
		[HttpPost]
		public IActionResult MessageCreate(CreateMessageDto createMessageDto)
		{
			_messageService.TAdd(new Message()
			{
				MessageNameSurname = createMessageDto.MessageNameSurname,
				MessageSubject = createMessageDto.MessageSubject,
				MessageContent = createMessageDto.MessageContent,
				MessageMail = createMessageDto.MessageMail,
				MessagePhone = createMessageDto.MessagePhone,
				MessageStatus = false,
				MessageSendDate = DateTime.Now,
			});
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult MessageDelete(int id)
		{
			_messageService.TDelete(_messageService.TGetByID(id));
			return Ok();
		}
		[HttpPut]
		public IActionResult MessageUpdate(UpdateMessageDto updateMessageDto)
		{
			_messageService.TUpdate(new Message()
			{
				MessageID = updateMessageDto.MessageID,
				MessageNameSurname = updateMessageDto.MessageNameSurname,
				MessageSubject = updateMessageDto.MessageSubject,
				MessageContent = updateMessageDto.MessageContent,
				MessageMail = updateMessageDto.MessageMail,
				MessagePhone = updateMessageDto.MessagePhone,
				MessageStatus = false,
				MessageSendDate = updateMessageDto.MessageSendDate,
			});
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult MessageGet(int id)
		{
			return Ok(_messageService.TGetByID(id));
		}
	}
}
