using FluentValidation;
using JwtSolution.Dtos.AppUserDtos;

namespace JwtSolution.Business.ValidationRules.FluentValidation
{
    public class AppUserLoginValidator : AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı zorunludur");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şife zorunludur");
        }
    }
}
