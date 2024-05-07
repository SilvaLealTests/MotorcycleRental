using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MotorcycleRental.Application.Auth.Dtos;
using MotorcycleRental.Application.Auth.Services;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Domain.Exceptions;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MotorcycleRental.Application.Auth.Commands
{
    public class AuthenticationCommandHandler(
        ILogger<AuthenticationCommandHandler> logger,
        UserManager<User> userManager,
        ITokenService tokenService
        ) : IRequestHandler<AuthenticationCommand, LoginResultDto>
    {
       public async Task<LoginResultDto> Handle(AuthenticationCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Trying to do login...");
            var user = await userManager.FindByEmailAsync(request.Email);
            if (user != null && await userManager.CheckPasswordAsync(user,request.Password)) {

                var token = await tokenService.GenerateToken(user);
                var refreshToken = "";// GenerateRefreshToken();

                return new LoginResultDto()
                {
                    TokenType = "Bearer",
                    AccessToken = token,
                    ExpiresIn = 3600,
                    RefreshToken = refreshToken
                };
            }

            throw new BadRequestException("Email or password invalid");


        }
   


    //public string GenerateJwtToken(IdentityUser user)
    //{
    //    var tokenHandler = new JwtSecurityTokenHandler();
    //    var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);
    //    var tokenDescriptor = new SecurityTokenDescriptor
    //    {
    //        Subject = new ClaimsIdentity(new Claim[]
    //        {
    //            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
    //            new Claim(ClaimTypes.Email, user.Email)
    //        }),
    //        Expires = DateTime.UtcNow.AddMinutes(15),
    //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    //    };

    //    var token = tokenHandler.CreateToken(tokenDescriptor);
    //    return tokenHandler.WriteToken(token);
    //}

    //public string GenerateRefreshToken()
    //{
    //    var randomNumber = new byte[32];
    //    using (var rng = RandomNumberGenerator.Create())
    //    {
    //        rng.GetBytes(randomNumber);
    //        return Convert.ToBase64String(randomNumber);
    //    }
    //}
    }

}
