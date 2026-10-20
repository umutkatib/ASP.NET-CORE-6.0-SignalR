using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BookingDtos;
using SignalRWebUI.Models;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Controllers
{
	public class BookingController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BookingController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7171/api/Bookings");
			if(responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult BookingCreate()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> BookingCreate(CreateBookingDto createBookingDto)
		{
			createBookingDto.BookingDescription = "Rezervasyon Alındı";
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createBookingDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7171/api/Bookings", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				TempData["SuccessMessage"] = "Rezervasyon Kaydi Basarili Bir Sekilde Eklendi!";
				return RedirectToAction("Index");
			}

			var errorResponse = await responseMessage.Content.ReadFromJsonAsync<ApiValidationErrorResponse>();
			if(errorResponse?.Errors != null)
			{
				foreach(var error in errorResponse.Errors)
				{
					foreach(var errorMessage in error.Value)
					{
						ModelState.AddModelError(error.Key, errorMessage);
					}
				}
			}
			TempData["ErrorMessage"] = "Rezervasyon Kaydi Eklenemedi!";

			return View(createBookingDto);
		}

		public async Task<IActionResult> BookingDelete(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMesssage = await client.DeleteAsync($"https://localhost:7171/api/Bookings/{id}");
			if(responseMesssage.IsSuccessStatusCode)
			{
				TempData["DeleteMessage"] = "Rezervasyon Kaydi Basarili Bir Sekilde Silindi!";
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> BookingUpdate(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMesssage = await client.GetAsync($"https://localhost:7171/api/Bookings/{id}");
			if (responseMesssage.IsSuccessStatusCode)
			{
				var jsonData = await responseMesssage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
				return View(value);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> BookingUpdate(UpdateBookingDto updateBookingDto)
		{
			updateBookingDto.BookingDescription = "Rezervasyon Alındı";
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateBookingDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7171/api/Bookings", stringContent);

			if (responseMessage.IsSuccessStatusCode)
			{
				TempData["SuccessMessage"] = "Rezervasyon Kaydi Basarili Bir Sekilde Güncellendi!";
				return RedirectToAction("Index");
			}

			var errorResponse = await responseMessage.Content.ReadFromJsonAsync<ApiValidationErrorResponse>();
			if (errorResponse?.Errors != null)
			{
				foreach (var error in errorResponse.Errors)
				{
					foreach (var errorMessage in error.Value)
					{
						ModelState.AddModelError(error.Key, errorMessage);
					}
				}
			}
			TempData["ErrorMessage"] = "Rezervasyon Kaydi Güncellenemedi!";

			return View(updateBookingDto);
		}

		public async Task<IActionResult> BookingStatusApproved(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync($"https://localhost:7171/api/Bookings/BookingStatusApproved/{id}");
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> BookingStatusCancelled(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync($"https://localhost:7171/api/Bookings/BookingStatusCancelled/{id}");
			return RedirectToAction("Index");
		}
	}
}
