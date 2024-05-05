using FluentValidation;
using MotorcycleRental.Application.Motorcycles.Commands.CreateMotorcycles;

namespace MotorcycleRental.Application.Motorcycles.Dtos.Validators
{
    public class CreateMotocycleDtoValidator : AbstractValidator<CreateMotorcyclesCommand>
    {
        public CreateMotocycleDtoValidator()
        {
            RuleFor(dto => dto.Year)
                .NotEmpty()
                .WithMessage("Insert a valid Year");

            RuleFor(dto => dto.Model)
                .NotEmpty()
                .WithMessage("Insert the Model")
                .MaximumLength(50)
                .WithMessage("Model cannot have more than {0} characters");

            RuleFor(dto => dto.LicensePlate)
                .Matches(@"^[a-zA-Z]{3}[0-9][A-Za-z0-9][0-9]{2}$")
                .WithMessage("Please provide in a valid format");

        }
    }
}
