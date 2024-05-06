using Xunit;
using MotorcycleRental.Application.Motorcycles.Commands.CreateMotorcycle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.TestHelper;

namespace MotorcycleRental.Application.Motorcycles.Commands.CreateMotorcycle.Tests
{
    public class CreateMotorcyclesCommandValidatorTests
    {
        [Fact()]
            public void validator_ForValidCommand_ShouldNotHaveValitationErrors()
        {
            //arrange
            var command = new CreateMotorcycleCommand()
            {
                LicensePlate = "ABC-1234",
                Model = 2022,
                Year = 2023,
                Description = "Yamaha 125"
            };

            var validator = new CreateMotorcycleCommandValidator();

            //act

            var result = validator.TestValidate(command);

            //assert

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact()]
        public void validator_ForValidCommand_ShouldHaveValidationErrors()
        {
            //arrange

            var command = new CreateMotorcycleCommand()
            {
                LicensePlate = "454-4",                
                Year = 21,
                Model = 20
            };

            var validator = new CreateMotorcycleCommandValidator();

            //act

            var result = validator.TestValidate(command);

            //assert

            result.ShouldHaveValidationErrorFor(c => c.LicensePlate);          
            result.ShouldHaveValidationErrorFor(c => c.Year);
            result.ShouldHaveValidationErrorFor(c => c.Model);

        }
    }
}