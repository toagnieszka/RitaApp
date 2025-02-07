using FluentValidation;
using RitaApp.DTOs.UpdateDto;

namespace RitaApp.DTOs.Validation
{
    public class UpdateUnitDtoValidator : AbstractValidator<UpdateUnitDto>
    {
        public UpdateUnitDtoValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Pole nie może być puste.")
               .MaximumLength(30).WithMessage("Maksymalna ilość znaków to 30.")
               .Matches(@"^[a-zA-Z0-9\sąćęłńóśźżĄĆĘŁŃÓŚŹŻ]+$").WithMessage("Pole nie może zawierać znaków specjalnych");

            RuleFor(x => x.Id)
               .NotNull().WithMessage("Nie odnaleziono takiego obiektu")
               .NotEmpty().WithMessage("Pole nie może być puste.");

			RuleFor(x => x.ShortName)
			   .NotEmpty().WithMessage("Pole nie może być puste.")
			   .MaximumLength(6).WithMessage("Maksymalna ilość znaków to 6.");
		}
    }
}
