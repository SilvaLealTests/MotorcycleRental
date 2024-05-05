using FluentValidation;

namespace MotorcycleRental.Application.Motorcycles.Commands.CreateMotorcycles
{
    public class CreateMotorcyclesCommandValidator : AbstractValidator<CreateMotorcyclesCommand>
    {
        public CreateMotorcyclesCommandValidator()
        {
            RuleFor(dto => dto.Model).Length(3, 4);
            RuleFor(dto => dto.Year.ToString()).Length(3, 4);
            RuleFor(dto => dto.LicensePlate).Matches(@"^([A-Z]{3}-[0-9]{4}|[A-Z]{3}[0-9][A-Z][0-9]{2})$")
                .WithMessage("Please provide a valid License Plate (###-####).");
        }
    }
}
