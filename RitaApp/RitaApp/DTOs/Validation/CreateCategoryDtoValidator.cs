﻿using FluentValidation;
using RitaApp.DTOs.CreateDto;

namespace RitaApp.DTOs.Validation
{
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Pole nie może być puste.")
                .MaximumLength(30).WithMessage("Maksymalna ilość znaków to 30.")
                .Matches(@"^[a-zA-Z0-9\sąćęłńóśźżĄĆĘŁŃÓŚŹŻ]+$").WithMessage("Pole nie może zawierać znaków specjalnych");
        }
    }
}
