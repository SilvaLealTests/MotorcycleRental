using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MotorcycleRental.Domain.Constants;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Domain.Exceptions;
using MotorcycleRental.Domain.Repositories;

namespace MotorcycleRental.Application.Users.Commands.BikerRegister
{
    public class BikerRegisterCommandHandler(
        IUserRepository repository,
        ILogger<BikerRegisterCommandHandler> logger,
        IUserStore<User> userStore,
        UserManager<User> userManager,
        IUserContext userContext
        ) : IRequestHandler<BikerRegisterCommand, bool>
    {
        
        public async Task<bool> Handle(BikerRegisterCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating a Bike User {BikeUser}",request);


            validations(request);

        User user = new User();
            user.Biker = request.Biker;
            user.UserType = UserType.Biker;
            user.Email = request.Email;             
            user.UserName = request.Email;
            user.NormalizedUserName = request.Email.ToUpper();
            user.NormalizedEmail = request.Email.ToUpper();            

            

            //var dbUser = await userStore.CreateAsync(user, cancellationToken);

            return await repository.InsertBiker(user,request.Password);
            
        }

        private void validations(BikerRegisterCommand request)
        {
            //do not allow registration for the same CNPJ
            var userWithSameCNPJ = userManager.Users.Where(x => x.Biker.CNPJ == request.Biker.CNPJ).FirstOrDefault();

            if (userWithSameCNPJ != null)
                throw new ForbidException("The CNPJ already exists");


            //do not allow registration for the same CNH
            var userWithSameCNH = userManager.Users.Where(x => x.Biker.CNH == request.Biker.CNH).FirstOrDefault();

            if (userWithSameCNH != null)
                throw new ForbidException("The CNH already exists");

        }
    }
}
