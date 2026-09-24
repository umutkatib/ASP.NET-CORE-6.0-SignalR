using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
	public class LayoutOfUIController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
