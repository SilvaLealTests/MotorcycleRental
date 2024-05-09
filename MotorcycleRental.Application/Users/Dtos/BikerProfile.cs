using AutoMapper;
using MotorcycleRental.Domain.Entities;

namespace MotorcycleRental.Application.Users.Dtos
{
    public class BikerProfile : Profile
    {
        public BikerProfile()
        {
            CreateMap<BikerDto, Biker>();
            CreateMap<Biker, BikerDto>();
        }
    }
}
