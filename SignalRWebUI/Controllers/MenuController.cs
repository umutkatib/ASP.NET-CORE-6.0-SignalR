using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Dtos.ProductDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	[AllowAnonymous]
	public class MenuController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public MenuController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index(int id)
		{
			ViewBag.v = id;
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7171/api/Products/ProductListWithCategory");
			if(responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
				return View(values);	
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> BasketAdd(int id, int menuTableId)
		{
			if (menuTableId == 0)
			{
				return BadRequest("HATA!");
			}
			CreateBasketDto createBasketDto = new CreateBasketDto()
			{
				ProductID = id,
				MenuTableID = menuTableId
			};
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createBasketDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7171/api/Baskets", stringContent);

			var client2 = _httpClientFactory.CreateClient();
			await client.GetAsync($"https://localhost:7171/api/MenuTables/ChangeMenuTableStatusToTrue/{menuTableId}");

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return Json(createBasketDto);
		}
	}
}
