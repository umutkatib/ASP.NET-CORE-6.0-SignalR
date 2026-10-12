using AutoMapper;
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
		private readonly IMapper _mapper;

		public MessagesController(IMessageService messageService, IMapper mapper)
		{
			_messageService = messageService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult MessageList()
		{
			return Ok(_mapper.Map<List<ResultMessageDto>>(_messageService.TGetListAll()));
		}
		[HttpPost]
		public IActionResult MessageCreate(CreateMessageDto createMessageDto)
		{
			createMessageDto.MessageStatus = false;
			createMessageDto.MessageSendDate = DateTime.Now;
			var value = _mapper.Map<Message>(createMessageDto);
			_messageService.TAdd(value);
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
			updateMessageDto.MessageStatus = false;
			var value = _mapper.Map<Message>(updateMessageDto);
			_messageService.TUpdate(value);
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult MessageGet(int id)
		{
			var value = _messageService.TGetByID(id);
			return Ok(_mapper.Map<GetMessageDto>(value));
		}
	}
}
