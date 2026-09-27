using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.MenuLayoutComponents
{
	public class _MenuNavbarPartialComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
