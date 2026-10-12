using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using SignalRWebUI.Dtos.MailDtos;

namespace SignalRWebUI.Controllers
{
	public class MailController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(CreateMailDto createMailDto)
		{
			MimeMessage mimeMessage = new MimeMessage();

			MailboxAddress mailboxAddress = new MailboxAddress("SignalR Rezervasyon", "mail adresi");
			mimeMessage.From.Add(mailboxAddress);

			MailboxAddress mailboxAddressTo = new MailboxAddress("User", createMailDto.ReceiverMail);
			mimeMessage.To.Add(mailboxAddressTo);

			var bodyBuilder = new BodyBuilder();
			bodyBuilder.TextBody = createMailDto.Content;
			mimeMessage.Body = bodyBuilder.ToMessageBody();

			mimeMessage.Subject = createMailDto.Subject;
			SmtpClient smtpClient = new SmtpClient();
			smtpClient.Connect("smtp.gmail.com", 587, false);
			smtpClient.Authenticate("mail adresi", "gmail key");

			smtpClient.Send(mimeMessage);
			smtpClient.Disconnect(true);
			return RedirectToAction("Index", "Category");
		}
	}
}
