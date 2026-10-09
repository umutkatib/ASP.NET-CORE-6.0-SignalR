using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SocialMediaDtos;
using System.Threading.Tasks;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
	public class _DefaultSocialPartialComponent : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DefaultSocialPartialComponent(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7171/api/SocialMedias");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
