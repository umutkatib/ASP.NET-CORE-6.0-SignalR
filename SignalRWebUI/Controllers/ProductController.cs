using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.CategoryDtos;
using SignalRWebUI.Dtos.ProductDtos;
using SignalRWebUI.Extensions;
using SignalRWebUI.Models;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class ProductController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7171/api/Products/ProductListWithCategory");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		private async Task LoadCategoriesAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7171/api/Categories");
			var jsonData = await responseMessage.Content.ReadAsStringAsync();
			var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

			ViewBag.v = (from x in values
						 select new SelectListItem
						 {
							 Text = x.CategoryName,
							 Value = x.CategoryID.ToString()
						 }).ToList();
		}

		[HttpGet]
		public async Task<IActionResult> ProductCreate()
		{
			await LoadCategoriesAsync();
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> ProductCreate(CreateProductDto createProductDto)
		{
			if(!ModelState.IsValid)
			{
				await LoadCategoriesAsync();
				return View(createProductDto);
			}
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createProductDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7171/api/Products", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			await ModelState.AddApiErrorsAsync(responseMessage);
			await LoadCategoriesAsync();
			return View(createProductDto);
		}

		public async Task<IActionResult> ProductDelete(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7171/api/Products/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> ProductUpdate(int id)
		{
			await LoadCategoriesAsync();

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7171/api/Products/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
				return View(value);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> ProductUpdate(UpdateProductDto updateProductDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateProductDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7171/api/Products", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}

			await ModelState.AddApiErrorsAsync(responseMessage);
			return View(updateProductDto);
		}

		public async Task<IActionResult> ChangeProductStatusToFalse(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync($"https://localhost:7171/api/Products/ChangeProductStatusToFalse/{id}");
			return RedirectToAction("Index");
		}
		public async Task<IActionResult> ChangeProductStatusToTrue(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync($"https://localhost:7171/api/Products/ChangeProductStatusToTrue/{id}");
			return RedirectToAction("Index");
		}
	}
}
