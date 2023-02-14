using FluentValidation;
using GeekShopping.ProductAPI.Data.ValueObjects;

namespace GeekShopping.ProductAPI.Validators;

public sealed class ProductValidator : AbstractValidator<ProductVo>
{
	public ProductValidator()
	{
		RuleFor(p => p.Name)
			.NotEmpty()
			.NotNull().WithMessage("{PropertyName} is required!")
			.MinimumLength(4).WithMessage("{PropertyName} must be greather than 4 characters!")
			.MaximumLength(150).WithMessage("{PropertyName} must be less than 150 characters!");

		RuleFor(p => p.Price)
			.NotEmpty()
			.NotNull().WithMessage("{PropertyName} is required!")
			.GreaterThan(1).WithMessage("{PropertyName} must be greather than 1!")
			.LessThan(10000).WithMessage("{PropertyName} must be less than 10000!");

		RuleFor(p => p.Description)
			.MinimumLength(6).WithMessage("{PropertyName} must be greather than 6 characters!")
			.MaximumLength(500).WithMessage("{PropertyName} must be less than 500 characters!");

		RuleFor(p => p.CategoryName)
			.MinimumLength(4).WithMessage("{PropertyName} must be greather than 4 characters!")
			.MaximumLength(50).WithMessage("{PropertyName} must be less than 50 characters!");

		RuleFor(p => p.ImageUrl)
			.MinimumLength(4).WithMessage("{PropertyName} must be greather than 4 characters!")
			.MaximumLength(300).WithMessage("{PropertyName} must be less than 300 characters!");
	}
}
