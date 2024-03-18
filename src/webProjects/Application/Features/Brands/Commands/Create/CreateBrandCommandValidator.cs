using Application.Features.Brands.Constants;
using FluentValidation;

namespace Application.Features.Brands.Commands.Create;

public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(b => b.Name).NotEmpty().WithMessage(BrandValidatorMessages.NameNotBlank);
        RuleFor(b => b.Name).MinimumLength(2);
    }
}

//** RuleFor yöntemi, bir model sınıfının belirli bir özelliği (property)
//için doğrulama kuralları tanımlamak için kullanılır.**///