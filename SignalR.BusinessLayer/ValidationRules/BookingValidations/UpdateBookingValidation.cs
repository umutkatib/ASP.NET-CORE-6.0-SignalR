using FluentValidation;
using SignalR.DtoLayer.BookingDto;

namespace SignalR.BusinessLayer.ValidationRules.BookingValidations
{
	public class UpdateBookingValidation : AbstractValidator<UpdateBookingDto>
	{
		public UpdateBookingValidation()
		{
			RuleFor(x => x.BookingName).NotEmpty().WithMessage("İsim boş geçilemez!");
			RuleFor(x => x.BookingPhone).NotEmpty().WithMessage("Telefon boş geçilemez!");
			RuleFor(x => x.BookingMail).NotEmpty().WithMessage("Mail boş geçilemez!");
			RuleFor(x => x.BookingPersonCount).NotEmpty().WithMessage("Kişi alanı boş geçilemez!");
			RuleFor(x => x.BookingDate).NotEmpty().WithMessage("Tarih boş geçilemez!");

			RuleFor(x => x.BookingName).MinimumLength(2).WithMessage("İsminiz en az 2 karakter olabilir!")
				.MaximumLength(50).WithMessage("İsminiz en fazla 50 karakter olabilir!");
			RuleFor(x => x.BookingDescription).MaximumLength(250).WithMessage("Açıklamanız en fazla 250 karakter olabilir!");

			RuleFor(x => x.BookingMail).EmailAddress().WithMessage("Lütfen geçerli bir email giriniz!");
		}
	}
}
