using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;
using System.Threading.Tasks;

namespace SignalRWebUI.Controllers
{
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> _signInManager;

		public LoginController(SignInManager<AppUser> signInManager)
		{
			_signInManager = signInManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(LoginDto loginDto)
		{
			if (!ModelState.IsValid) 
				return View(loginDto);

			var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);

			if (result.Succeeded)
			{
				return RedirectToAction("Index", "Category");
			}
			else
				ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!");

			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Login");
		}
	}
}
