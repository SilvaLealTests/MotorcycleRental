using MediatR;
using Microsoft.AspNetCore.Identity;
using MotorcycleRental.Application.Users.Dtos;
using MotorcycleRental.Domain.Entities;

namespace MotorcycleRental.Application.Users.Commands.BikerRegister
{
    public class BikerRegisterCommand : IRequest<bool>
    {
        public string Email { get; set; }

        public string Password { get; set; }
        public BikerDto BikerDto { get; set; } = new();
    }
}
