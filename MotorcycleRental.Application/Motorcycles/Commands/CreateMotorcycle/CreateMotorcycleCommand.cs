﻿using MediatR;

namespace MotorcycleRental.Application.Motorcycles.Commands.CreateMotorcycle
{
    public class CreateMotorcycleCommand : IRequest<int>
    {
        public string  Description { get; set; }
        public int Year { get; set; }

        public int Model { get; set; } = default!;

        public string LicensePlate { get; set; } = default!;
    }
}