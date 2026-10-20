using FluentValidation;
using SignalR.DtoLayer.CategoryDto;

namespace SignalR.BusinessLayer.ValidationRules.CategoryValidations
{
	public class CreateCategoryValidation : AbstractValidator<CreateCategoryDto>
	{
		public CreateCategoryValidation()
		{
			RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez!");
			RuleFor(x => x.CategoryStatus).NotEmpty();

			RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Kategori adı en az 2 karakter olabilir!")
				.MaximumLength(25).WithMessage("Kategori adı en fazla 25 karakter olabilir!");
		}
	}
}
