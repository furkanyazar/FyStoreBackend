using Entities.Dtos.Products;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.Products;

public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
{
    public UpdateProductDtoValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Name).MinimumLength(2);
    }
}