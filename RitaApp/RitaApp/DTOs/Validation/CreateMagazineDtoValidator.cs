﻿using FluentValidation;
using RitaApp.DTOs.CreateDto;

namespace RitaApp.DTOs.Validation
{
    public class CreateMagazineDtoValidator : AbstractValidator<CreateMagazineDto>
    {
        public CreateMagazineDtoValidator()
        {
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Pole nie może być puste.")
               .MaximumLength(30).WithMessage("Maksymalna ilość znaków to 30.")
               .Matches(@"^[a-zA-Z0-9\sąćęłńóśźżĄĆĘŁŃÓŚŹŻ]+$").WithMessage("Pole nie może zawierać znaków specjalnych");

            RuleFor(x => x.Location)
               .NotEmpty().WithMessage("Pole nie może być puste.")
               .MaximumLength(50).WithMessage("Maksymalna ilość znaków to 50.");
        }
    }
}
