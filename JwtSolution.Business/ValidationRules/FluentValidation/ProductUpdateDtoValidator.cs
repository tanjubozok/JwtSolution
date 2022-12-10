using FluentValidation;
using JwtSolution.Dtos.ProductDtos;

namespace JwtSolution.Business.ValidationRules.FluentValidation
{
    public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator()
        {
            RuleFor(x => x.Id).InclusiveBetween(0, int.MaxValue);
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı zorunludur");
        }
    }
}
