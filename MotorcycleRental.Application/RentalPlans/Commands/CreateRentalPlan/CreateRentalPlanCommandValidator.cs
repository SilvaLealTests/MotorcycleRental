using FluentValidation;

namespace MotorcycleRental.Application.RentalPlans.Commands.CreateRentalPlan
{
    public class CreateRentalPlanCommandValidator : AbstractValidator<CreateRentalPlanCommand>
    {
        public CreateRentalPlanCommandValidator()
        {
            RuleFor(dto => dto.Cost).NotEmpty();
            RuleFor(dto => dto.Description).NotEmpty();
            RuleFor(dto => dto.Days).NotEmpty();
        }
    }
}
