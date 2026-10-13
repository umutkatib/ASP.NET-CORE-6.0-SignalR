using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.Controllers
{
	[AllowAnonymous]
	public class ErrorController : Controller
	{
		public IActionResult NotFound404Page()
		{
			return View();
		}
		public IActionResult AccessDenied403Page()
		{
			return View();
		}
		public IActionResult InternalServer500Page()
		{
			return View();
		}
	}
}
