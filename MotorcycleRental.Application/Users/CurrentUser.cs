﻿using MotorcycleRental.Domain.Constants;

namespace MotorcycleRental.Application.Users
{
    public record CurrentUser(string Id, string Email, IEnumerable<string> Roles, UserType UserType)
    {
        public bool IsInRole(string role) => Roles.Contains(role);
    }
}
