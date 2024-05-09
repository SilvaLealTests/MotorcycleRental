using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Domain.Repositories;

namespace MotorcycleRental.Application.Users.Commands.BikerRegister
{
    public class BikerRegisterCommandHandler(
        IUsersRepository repository,
        ILogger<BikerRegisterCommandHandler> logger,
        IUserStore<User> userStore,
        IMapper mapper
        ) : IRequestHandler<BikerRegisterCommand, bool>
    {

        public async Task<bool> Handle(BikerRegisterCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating a Bike User {BikeUser}", request);

            User user = new User();
            user.Email = request.Email;
            user.UserName = request.Email;
            user.NormalizedUserName = request.Email.ToUpper();
            user.NormalizedEmail = request.Email.ToUpper();

            var biker = mapper.Map<Biker>(request.BikerDto);

            return await repository.InsertBiker(user, request.Password, biker);

        }
    }
}
