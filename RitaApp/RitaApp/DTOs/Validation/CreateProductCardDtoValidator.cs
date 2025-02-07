using FluentValidation;
using RitaApp.DTOs.CreateDto;

namespace RitaApp.DTOs.Validation
{
    public class CreateProductCardDtoValidator : AbstractValidator<CreateProductCardDto>
    {
        public CreateProductCardDtoValidator() 
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Pole nie może być puste.")
               .MaximumLength(100).WithMessage("Maksymalna ilość znaków to 100.")
               .Matches(@"^[a-zA-Z0-9\sąćęłńóśźżĄĆĘŁŃÓŚŹŻ]+$").WithMessage("Pole nie może zawierać znaków specjalnych");

            RuleFor(x => x.UnitId)
                .NotEmpty().WithMessage("Pole nie może być puste.");
        }
    }
}
