using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MotorcycleRental.Domain.Constants;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Domain.Repositories;

namespace MotorcycleRental.Application.Users.Commands.BikerRegister
{
    public class BikerRegisterCommandHandler(
        IUserRepository repository,
        ILogger<BikerRegisterCommandHandler> logger,
        IUserStore<User> userStore
        ) : IRequestHandler<BikerRegisterCommand, IdentityResult>
    {
        
        public async Task<IdentityResult> Handle(BikerRegisterCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating a Bike User {BikeUser}",request);

            

        User user = new User();
            user.Biker = request.Biker;
            user.UserType = UserType.Biker;
            user.Email = request.Email;
             
            user.UserName = request.Email;
            user.NormalizedUserName = request.Email.ToUpper();
            user.NormalizedEmail = request.Email.ToUpper();            

            

            //var dbUser = await userStore.CreateAsync(user, cancellationToken);

            var identityResult = await repository.InsertBiker(user,request.Password);

            return identityResult;

            
        }
    }
}
