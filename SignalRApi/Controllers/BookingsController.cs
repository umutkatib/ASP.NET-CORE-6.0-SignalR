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
			return Ok(_mapper.Map<List<ResultBookingDto>>(_bookingsService.TGetListAll()));
		}
		[HttpPost]
		public IActionResult BookingCreate(CreateBookingDto createBookingDto)
		{
			var value = _mapper.Map<Booking>(createBookingDto);
			_bookingsService.TAdd(value);
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
			var value = _mapper.Map<Booking>(updateBookingDto);
			_bookingsService.TUpdate(value);
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult BookingGet(int id)
		{
			var value = _bookingsService.TGetByID(id);
			return Ok(_mapper.Map<GetBookingDto>(value));
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

		[HttpGet("BookingCount")]
		public IActionResult BookingCount()
		{
			return Ok(_bookingsService.TBookingCount());
		}
	}
}
