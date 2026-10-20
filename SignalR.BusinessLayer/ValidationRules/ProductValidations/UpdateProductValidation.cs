using FluentValidation;
using SignalR.DtoLayer.ProductDto;

namespace SignalR.BusinessLayer.ValidationRules.ProductValidations
{
	public class UpdateProductValidation : AbstractValidator<UpdateProductDto>
	{
		public UpdateProductValidation()
		{
			RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün adı boş geçilemez!");
			RuleFor(x => x.ProductDescription).NotEmpty().WithMessage("Ürün açıklaması boş geçilemez!");
			RuleFor(x => x.ProductPrice).NotEmpty().WithMessage("Fiyat boş geçilemez!");
			RuleFor(x => x.ProductImageURl).NotEmpty().WithMessage("Resim yolu boş geçilemez!");
			RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Kategori boş geçilemez!");

			RuleFor(x => x.ProductName).MinimumLength(3).WithMessage("Ürün adı en az 2 karakter olabilir!")
				.MaximumLength(40).WithMessage("Ürün adı en fazla 40 karakter olabilir!");
			RuleFor(x => x.ProductDescription).MinimumLength(5).WithMessage("Ürün açıklaması en az 5 karakter olabilir!")
				.MaximumLength(100).WithMessage("Ürün açıklaması en fazla 100 karakter olabilir!");
		}
	}
}
