using FluentValidation;
using RitaApp.DTOs.CreateDto;
using static System.Net.Mime.MediaTypeNames;

namespace RitaApp.DTOs.Validation
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator() 
        {
            RuleFor(x => x.FirstName)
               .NotEmpty().WithMessage("Pole nie może być puste.")
               .MaximumLength(30).WithMessage("Maksymalna ilość znaków to 30.")
               .Matches("^[a-zA-Z0-9]*$").WithMessage("Pole nie może zawierać znaków specjalnych oraz spacji");

            RuleFor(x => x.LastName)
               .NotEmpty().WithMessage("Pole nie może być puste.")
               .MaximumLength(30).WithMessage("Maksymalna ilość znaków to 30.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Pole nie może być puste.")
                .MaximumLength(50).WithMessage("Maksymalna ilość znaków to 50.")
                .Matches("@").WithMessage("Niepoprawny adres e-mail.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Pole nie może być puste.")
                .MinimumLength(8).WithMessage("Minimalna ilość znaków to 8.")
                .MaximumLength(30).WithMessage("Maksymalna ilość znaków to 30.")
                .Matches(@"[0-9]").WithMessage("Hasło musi zawierać przynajmniej jedną cyfrę.")
                .Matches(@"[!@#$%^&*(),.?""{}|<>]").WithMessage("Hasło musi zawierać przynajmniej jeden znak specjalny.")
                .Matches("[A-Z]").WithMessage("Hasło musi zawierać przynajmniej jedną duża literę")
                .Matches("[a-z]").WithMessage("Hasło musi zawierać przynajmniej jedną małą literę");
        }
    }
}
