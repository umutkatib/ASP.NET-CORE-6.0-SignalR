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
			var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
			return Ok(values);
		}
		[HttpPost]
		public IActionResult ContactCreate(CreateContactDto createContactDto)
		{
			_contactService.TAdd(new Contact()
			{
				ContactMail = createContactDto.ContactMail,
				ContactFooterDescription = createContactDto.ContactFooterDescription,
				ContactLocation = createContactDto.ContactLocation,
				ContactPhoneNumber = createContactDto.ContactPhoneNumber,
				ContactOpenDays = createContactDto.ContactOpenDays,
				ContactOpenDescription = createContactDto.ContactOpenDescription,
				ContactOpenHours = createContactDto.ContactOpenHours,
				ContactTitle = createContactDto.ContactTitle,
			});
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
			_contactService.TUpdate(new Contact()
			{
				ContactID = updateContactDto.ContactID,
				ContactMail = updateContactDto.ContactMail,
				ContactFooterDescription = updateContactDto.ContactFooterDescription,
				ContactLocation = updateContactDto.ContactLocation,
				ContactPhoneNumber = updateContactDto.ContactPhoneNumber,
				ContactOpenDays = updateContactDto.ContactOpenDays,
				ContactOpenDescription = updateContactDto.ContactOpenDescription,
				ContactOpenHours = updateContactDto.ContactOpenHours,
				ContactTitle = updateContactDto.ContactTitle,
			});
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult ContactGet(int id)
		{
			var value = _contactService.TGetByID(id);
			return Ok(value);
		}
	}
}
