using Microsoft.AspNetCore.Mvc;
using QRCoder;
using System.Drawing;
using System.Drawing.Imaging;

namespace SignalRWebUI.Controllers
{
	public class QRCodeController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Index(string value)
		{
			if (string.IsNullOrWhiteSpace(value))
			{
				ViewBag.Error = "Lütfen bir değer girin.";
				return View();
			}
			using var qrGenerator = new QRCodeGenerator();
			using var qrCodeData = qrGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
			var pngQrCode = new PngByteQRCode(qrCodeData);
			byte[] qrBytes = pngQrCode.GetGraphic(10);

			ViewBag.QrCodeImage = "data:image/png;base64," + Convert.ToBase64String(qrBytes);
			ViewBag.Value = value;

			//using (MemoryStream memoryStream = new MemoryStream())
			//{
			//	QRCodeGenerator createQRCode = new QRCodeGenerator();
			//	QRCodeGenerator.QRCode squareCode = createQRCode.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);
			//	using (Bitmap image = squareCode.GetGraphic(10))
			//	{
			//		image.Save(memoryStream, ImageFormat.Png);
			//		ViewBag.QrCodeImage = "data:image/png;base64" + Convert.ToBase64String(memoryStream.ToArray());
			//	};
			//};
			return View();
		}
	}
}
