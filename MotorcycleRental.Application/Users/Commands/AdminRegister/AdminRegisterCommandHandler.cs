using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MotorcycleRental.Domain.Constants;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Domain.Repositories;

namespace MotorcycleRental.Application.Users.Commands.AdminRegister
{
    public class AdminRegisterCommandHandler(
        IUserRepository respository,
        ILogger<AdminRegisterCommandHandler> logger
        ) : IRequestHandler<AdminRegisterCommand,bool>
    {
        public async Task<bool> Handle(AdminRegisterCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating a Admin User {@request}", request);

            User user = new User();            
            user.UserType = UserType.Admin;
            user.Email = request.Email;
            user.UserName = request.Email;
            user.NormalizedUserName = request.Email.ToUpper();
            user.NormalizedEmail = request.Email.ToUpper();

            var identityResult = await respository.InsertAdmin(user, request.Password);

            return identityResult;
        }
    }
}
