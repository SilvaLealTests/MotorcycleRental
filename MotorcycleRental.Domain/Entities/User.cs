using Microsoft.AspNetCore.Identity;
using MotorcycleRental.Domain.Constants;

namespace MotorcycleRental.Domain.Entities
{
    public class User : IdentityUser
    {
        public UserType UserType { get; set; }

        public Biker Biker { get; set; }

        public List<Rent>? Rents { get; set; } 

    }
}
