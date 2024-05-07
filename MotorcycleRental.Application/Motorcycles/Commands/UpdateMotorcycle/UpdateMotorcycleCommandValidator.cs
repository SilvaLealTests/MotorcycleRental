using FluentValidation;

namespace MotorcycleRental.Application.Motorcycles.Commands.UpdateMotorcycle
{
    public class UpdateMotorcycleCommandValidator : AbstractValidator<UpdateMotorcycleCommand>
    {
        public UpdateMotorcycleCommandValidator()
        {
            //RuleFor(dto => dto.Id).NotEmpty();

           // RuleFor(dto => dto.Description).Length(0, 100);

           // RuleFor(dto => dto.Model).InclusiveBetween(1000, 9999)
           //.WithMessage("The model must be a 4-digit number between 1000 and 9999.");

           // RuleFor(dto => dto.Year).InclusiveBetween(1000, 9999)
           // .WithMessage("The model must be a 4-digit number between 1000 and 9999.");

            RuleFor(dto => dto.LicensePlate).Matches(@"^([A-Z]{3}-[0-9]{4}|[A-Z]{3}-[0-9][A-Z][0-9]{2})$")
                .WithMessage("Please provide a valid License Plate (###-####).");
        }
    }
}
