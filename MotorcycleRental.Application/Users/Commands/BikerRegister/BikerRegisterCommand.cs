using MediatR;
using Microsoft.AspNetCore.Identity;
using MotorcycleRental.Domain.Constants;
using MotorcycleRental.Domain.Entities;

namespace MotorcycleRental.Application.Users.Commands.BikerRegister
{
    public class BikerRegisterCommand : IRequest<IdentityResult>
    {
        public string Email { get; set; }

        public string Password { get; set; }
        public Biker Biker { get; set; } = new();
    }
}
