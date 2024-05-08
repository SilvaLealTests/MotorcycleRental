using FluentValidation;

namespace MotorcycleRental.Application.Rents.Commands.CreateRent
{
    public class CreateRentCommandValidator : AbstractValidator<CreateRentCommand>
    {
        public CreateRentCommandValidator()
        {
            RuleFor(dto => dto.MotorcycleId)
                .NotEmpty();

           

            RuleFor(dto => dto.RentPlanId)
                .NotEmpty();
        }
    }
}
