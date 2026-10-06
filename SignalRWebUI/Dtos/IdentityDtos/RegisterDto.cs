using System.ComponentModel.DataAnnotations;

namespace SignalRWebUI.Dtos.IdentityDtos
{
	public class RegisterDto
	{
		[Required(ErrorMessage = "Ad alanı boş bırakılamaz.")]
		public string Name { get; set; }
		[Required(ErrorMessage = "Soyad alanı boş bırakılamaz.")]
		public string Surname { get; set; }
		[Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz.")]
		public string UserName { get; set; }
		[Required(ErrorMessage = "E-posta adresi boş bırakılamaz.")]
		public string Mail { get; set; }
		[Required(ErrorMessage = "Şifre boş bırakılamaz.")]
		[MinLength(5, ErrorMessage = "Şifre en az 5 karakter olmalıdır.")]
		public string Password { get; set; }
	}
}
