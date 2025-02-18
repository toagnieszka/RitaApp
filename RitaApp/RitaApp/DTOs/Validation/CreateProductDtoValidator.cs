using FluentValidation;
using RitaApp.DTOs.CreateDto;

namespace RitaApp.DTOs.Validation
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator() 
        {
            RuleFor(x => x.ProductCardId)
                .NotEmpty().WithMessage("Pole nie może być puste.");

            RuleFor(x => x.MagazineId)
                .NotEmpty().WithMessage("Pole nie może być puste.");

            RuleFor(x => x.Amount)
                .NotEmpty().WithMessage("Pole nie może być puste.")
                .GreaterThan(0).WithMessage("Ilość musi być większa od 0");

            RuleFor(x => x.Status)
                .IsInEnum().WithMessage("Nieprawidłowa wartość.");

            RuleFor(x => x.Comment)
                .MaximumLength(500).WithMessage("Maksymalna ilość znaków to 500.");

            RuleFor(x => x.LoanDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Data nie może być z przyszłości.");

            RuleFor(x => x.Lender)
                .MaximumLength(60).WithMessage("Maksymalna ilość znaków to 60.");

            RuleFor(x => x.Borrower)
                .MaximumLength(60).WithMessage("Maksymalna ilość znaków to 60.");
        }
    }
}
