using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Identity;
using Moq;
using MotorcycleRental.Domain.Constants;
using MotorcycleRental.Domain.Entities;
using Xunit;

namespace MotorcycleRental.Application.Users.Commands.BikerRegister.Tests
{
    public class BikerRegisterCommandValidatorTests
    {
        

        [Fact()]
        public void validator_ForValidCommand_ShouldNotHaveValidationErrors()
        {

            var identityUser = new Mock<UserManager<User>>();

            //arrange
            var command = new BikerRegisterCommand()
            {
                Email = "fulano@teste.com",
                Password = "Password1",
                Biker = new Domain.Entities.Biker()
                {
                    CNH = "99999999999",
                    CNHType = CNHTypes.A,
                    CNPJ = "39.935.720/0001-84",
                    DateOfBirth = new DateOnly(1990, 2, 2)
                }
            };

            var validator = new BikerRegisterCommandValidator();
            //act

            var result = validator.TestValidate(command);

            //assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact()]
        public void validator_ForValidCommand_ShouldHaveValidationErrors()
        {
            //arrange
            var command = new BikerRegisterCommand()
            {
                Email = "fda",
                Password = "as",
                //Biker = new Domain.Entities.Biker()
                //{
                //    CNH = "33",
                //    CNPJ = "33",

                //}
            };

            var validator = new BikerRegisterCommandValidator();

            //act

            var result = validator.TestValidate(command);

            //asset                       
            
            result.ShouldHaveValidationErrorFor(dto => dto.Password);
            result.ShouldHaveValidationErrorFor(dto => dto.Email);
            //result.ShouldHaveValidationErrorFor(dto => dto.Biker.CNPJ);
            //result.ShouldHaveValidationErrorFor(dto => dto.Biker.CNH);
            //result.ShouldHaveValidationErrorFor(dto => dto.Biker.CNHType);
            //result.ShouldHaveValidationErrorFor(dto => dto.Biker.DateOfBirth);
        }

       
    }
}