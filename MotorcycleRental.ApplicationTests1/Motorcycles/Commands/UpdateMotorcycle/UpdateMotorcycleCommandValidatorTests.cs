using FluentValidation.TestHelper;
using Xunit;

namespace MotorcycleRental.Application.Motorcycles.Commands.UpdateMotorcycle.Tests
{
    public class UpdateMotorcycleCommandValidatorTests
    {
        [Fact()]
        public void validator_ForValidCommand_ShouldNotHaveValitationErrors()
        {
            //arrange
            var command = new UpdateMotorcycleCommand()
            {
                Id = 1,
                LicensePlate = "ABC-1234"
                //,
                //Model = 2022,
                //Year = 2023,
                //Description = "Yamaha 125"
            };

            var validator = new UpdateMotorcycleCommandValidator();

            //act

            var result = validator.TestValidate(command);

            //assert

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact()]
        public void validator_ForValidCommand_ShouldHaveValidationErrors()
        {
            //arrange

            var command = new UpdateMotorcycleCommand()
            {                
                LicensePlate = "454-4"
                //,
                //Year = 21,
                //Model = 20
            };

            var validator = new UpdateMotorcycleCommandValidator();

            //act

            var result = validator.TestValidate(command);

            //assert
            result.ShouldHaveValidationErrorFor(c => c.Id);
            result.ShouldHaveValidationErrorFor(c => c.LicensePlate);
            //result.ShouldHaveValidationErrorFor(c => c.Year);
            //result.ShouldHaveValidationErrorFor(c => c.Model);

        }
    }
}