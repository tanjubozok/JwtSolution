using FluentValidation;
using JwtSolution.Dtos.AppUserDtos;

namespace JwtSolution.Business.ValidationRules.FluentValidation
{
    public class AppUserAddDtoValidator : AbstractValidator<AppUserAddDto>
    {
        public AppUserAddDtoValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı zorunludur");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre zorunludur");
            RuleFor(x => x.Fullname).NotEmpty().WithMessage("Ad Soyad zorunludur");
        }
    }
}
