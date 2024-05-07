using FluentValidation;

namespace MotorcycleRental.Application.RentalPlans.Commands.UpdateRentalPlan
{
    public class UpdateRentalPlanCommandValidator : AbstractValidator<UpdateRentalPlanCommand>
    {
        public UpdateRentalPlanCommandValidator()
        {
            RuleFor(dto => dto.Cost).NotEmpty();
            RuleFor(dto => dto.Description).NotEmpty();
            RuleFor(dto => dto.Days).NotEmpty();
        }
    }
}
