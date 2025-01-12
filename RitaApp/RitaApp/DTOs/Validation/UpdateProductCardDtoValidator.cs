using FluentValidation;
using RitaApp.DTOs.UpdateDto;

namespace RitaApp.DTOs.Validation
{
    public class UpdateProductCardDtoValidator: AbstractValidator<UpdateProductCardDto>
    {
        public UpdateProductCardDtoValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Pole nie może być puste.")
               .MaximumLength(100).WithMessage("Maksymalna ilość znaków to 100.")
               .Matches(@"^[a-zA-Z0-9\sąćęłńóśźżĄĆĘŁŃÓŚŹŻ]+$").WithMessage("Pole nie może zawierać znaków specjalnych");

            RuleFor(x => x.UnitId)
                .NotEmpty().WithMessage("Pole nie może być puste.");

            RuleFor(x => x.CategoryId)
                .NotEmpty().WithMessage("Pole nie może być puste.");

            RuleFor(x => x.Id)
               .NotNull().WithMessage("Nie odnaleziono takiego obiektu")
               .NotEmpty().WithMessage("Pole nie może być puste.");
        }
    }
}
