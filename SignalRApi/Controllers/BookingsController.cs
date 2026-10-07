using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingsController : ControllerBase
	{
		private readonly IBookingService _bookingsService;
		private readonly IMapper _mapper;

		public BookingsController(IBookingService bookingsService, IMapper mapper)
		{
			_bookingsService = bookingsService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult BookingList()
		{
			var values = _mapper.Map<List<ResultBookingDto>>(_bookingsService.TGetListAll());
			return Ok(values);
		}
		[HttpPost]
		public IActionResult BookingCreate(CreateBookingDto createBookingDto)
		{
			_bookingsService.TAdd(new Booking()
			{
				BookingName = createBookingDto.BookingName,
				BookingMail = createBookingDto.BookingMail,
				BookingDate = createBookingDto.BookingDate,
				BookingPersonCount = createBookingDto.BookingPersonCount,
				BookingPhone = createBookingDto.BookingPhone,
				BookingDescription = createBookingDto.BookingDescription
			});
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult BookingDelete(int id)
		{
			var value = _bookingsService.TGetByID(id);
			_bookingsService.TDelete(value);
			return Ok();
		}
		[HttpPut]
		public IActionResult BookingUpdate(UpdateBookingDto updateBookingDto)
		{
			_bookingsService.TUpdate(new Booking()
			{
				BookingID = updateBookingDto.BookingID,
				BookingName = updateBookingDto.BookingName,
				BookingMail = updateBookingDto.BookingMail,
				BookingDate = updateBookingDto.BookingDate,
				BookingPersonCount = updateBookingDto.BookingPersonCount,
				BookingPhone = updateBookingDto.BookingPhone,
				BookingDescription = updateBookingDto.BookingDescription
			});
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult BookingGet(int id)
		{
			var value = _bookingsService.TGetByID(id);
			return Ok(value);
		}

		[HttpGet("BookingStatusApproved/{id}")]
		public IActionResult BookingStatusApproved(int id)
		{
			_bookingsService.TBookingStatusApproved(id);
			return Ok();
		}
		[HttpGet("BookingStatusCancelled/{id}")]
		public IActionResult BookingStatusCancelled(int id)
		{
			_bookingsService.TBookingStatusCancelled(id);
			return Ok();
		}

	}
}
