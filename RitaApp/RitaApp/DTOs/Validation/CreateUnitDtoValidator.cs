using FluentValidation;
using RitaApp.DTOs.CreateDto;

namespace RitaApp.DTOs.Validation
{
    public class CreateUnitDtoValidator : AbstractValidator<CreateUnitDto>
    {
        public CreateUnitDtoValidator() 
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Pole nie może być puste.")
               .MaximumLength(30).WithMessage("Maksymalna ilość znaków to 30.");

            RuleFor(x => x.ShortName)
               .NotEmpty().WithMessage("Pole nie może być puste.")
               .MaximumLength(10).WithMessage("Maksymalna ilość znaków to 10.");

		}
    }
}
