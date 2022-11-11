

using ApartmentManagement.Application.Features.Users.Commands.UserCreateCommand;

using FluentValidation;

namespace ApartmentManagement.Application.Features.Users.ValidationRules
{
    public class UserValidationRule:AbstractValidator<CreateUserCommand>
    {
        public UserValidationRule()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Boş Geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Boş Geçilemez");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Boş Geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Boş Geçilemez");
            RuleFor(x => x.TcNo).NotEmpty().WithMessage("Boş Geçilemez");
        }
    }
}
