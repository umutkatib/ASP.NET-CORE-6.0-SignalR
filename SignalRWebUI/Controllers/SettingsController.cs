using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalRWebUI.Dtos.IdentityDtos;

namespace SignalRWebUI.Controllers
{
	public class SettingsController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public SettingsController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var value = await _userManager.FindByNameAsync(User.Identity.Name);
			UserEditDto userEditDto = new UserEditDto()
			{
				Name = value.Name,
				Surname = value.Surname,
				UserName = value.UserName,
				Mail = value.Email,
			};
			return View(userEditDto);
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserEditDto userEditDto)
		{
			if(userEditDto.Password == userEditDto.PasswordConfirm)
			{
				var user = await _userManager.FindByNameAsync(User.Identity.Name);
				user.Name = userEditDto.Name;
				user.Surname = userEditDto.Surname;
				user.UserName = userEditDto.UserName;
				user.Email = userEditDto.Mail;
				user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditDto.Password);
				await _userManager.UpdateAsync(user);
				return RedirectToAction("Index", "Category");
			}
			return View();
		}
	}
}
