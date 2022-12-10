using FluentValidation;
using JwtSolution.Dtos.ProductDtos;

namespace JwtSolution.Business.ValidationRules.FluentValidation
{
    public class ProductAddDtoValidator : AbstractValidator<ProductAddDto>
    {
        public ProductAddDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı zorunludur");
        }
    }
}
