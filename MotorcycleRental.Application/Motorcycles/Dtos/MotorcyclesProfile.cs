using AutoMapper;
using MotorcycleRental.Application.Motorcycles.Commands.CreateMotorcycles;
using MotorcycleRental.Domain.Entities;

namespace MotorcycleRental.Application.Motorcycles.Dtos;

public class MotorcyclesProfile : Profile
{
    public MotorcyclesProfile()
    {
        CreateMap<CreateMotorcyclesCommand, Motorcycle>();
        CreateMap<Motorcycle, MotorcycleDto>();
    }
}
