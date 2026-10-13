using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
	[AllowAnonymous]
	public class RegisterController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public RegisterController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(RegisterDto registerDto)
		{
			if (!ModelState.IsValid)
				return View(registerDto);

			var appuser = new AppUser()
			{
				Name = registerDto.Name,
				Surname = registerDto.Surname,
				Email = registerDto.Mail,
				UserName = registerDto.UserName,
			};

			var result = await _userManager.CreateAsync(appuser, registerDto.Password);
			if(result.Succeeded)
			{
				var roleResult = await _userManager.AddToRoleAsync(appuser, "User");
				if (!roleResult.Succeeded)
				{
					await _userManager.DeleteAsync(appuser);
					ModelState.AddModelError("", "Kayıt tamamlanamadı, lütfen tekrar deneyin.");
					return View(registerDto);
				}
				return RedirectToAction("Index", "Login");
			}			


			foreach (var error in result.Errors)
			{
				switch (error.Code)
				{
					case "DuplicateUserName":
						ModelState.AddModelError(nameof(registerDto.UserName), "Bu kullanıcı adı zaten kullanılıyor.");
						break;
					case "DuplicateEmail":
						ModelState.AddModelError(nameof(registerDto.Mail), "Bu e-posta adresi zaten kayıtlı.");
						break;
					default:
						ModelState.AddModelError("", error.Description);
						break;
				}
			}

			return View(registerDto);
		}
	}
}
