using Entities.Dtos.Products;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.Products;

public class AddProductDtoValidator : AbstractValidator<AddProductDto>
{
    public AddProductDtoValidator()
    {
        RuleFor(c => c.CategoryId).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Name).MinimumLength(2);
    }
}