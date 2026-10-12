using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly IContactService _contactService;
		private readonly IMapper _mapper;

		public ContactsController(IContactService contactService, IMapper mapper)
		{
			_contactService = contactService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult ContactList()
		{
			return Ok(_mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll()));
		}
		[HttpPost]
		public IActionResult ContactCreate(CreateContactDto createContactDto)
		{
			var value = _mapper.Map<Contact>(createContactDto);
			_contactService.TAdd(value);
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult ContactDelete(int id)
		{
			var value = _contactService.TGetByID(id);
			_contactService.TDelete(value);
			return Ok();
		}
		[HttpPut] 
		public IActionResult ContactUpdate(UpdateContactDto updateContactDto)
		{
			var value = _mapper.Map<Contact>(updateContactDto);
			_contactService.TUpdate(value);
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult ContactGet(int id)
		{
			var value = _contactService.TGetByID(id);
			return Ok(_mapper.Map<GetContactDto>(value));
		}
	}
}
