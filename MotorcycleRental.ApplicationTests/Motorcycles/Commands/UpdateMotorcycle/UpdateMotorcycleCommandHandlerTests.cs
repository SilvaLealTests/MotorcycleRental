using Xunit;
using MotorcycleRental.Application.Motorcycles.Commands.UpdateMotorcycle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using MotorcycleRental.Application.Motorcycles.Commands.CreateMotorcycle;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Domain.Exceptions;
using MotorcycleRental.Infrastructure.Repositories;

namespace MotorcycleRental.Application.Motorcycles.Commands.UpdateMotorcycle.Tests
{
    public class UpdateMotorcycleCommandHandlerTests
    {
        private readonly Mock<IMotorcyclesRepository> _repositoryMock;
        private readonly Mock<ILogger<CreateMotorcycleCommandHandler>> _loggerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly UpdateMotorcycleCommandHandler _handler;

        public UpdateMotorcycleCommandHandlerTests()
        {
            _repositoryMock = new Mock<IMotorcyclesRepository>();
            _loggerMock = new Mock<ILogger<CreateMotorcycleCommandHandler>>();
            _mapperMock = new Mock<IMapper>();
            _handler = new UpdateMotorcycleCommandHandler(_repositoryMock.Object, _loggerMock.Object, _mapperMock.Object);
        }

        [Fact]
        public async Task Handle_WhenMotorcycleExists_ShouldUpdateMotorcycle()
        {
            // Arrange
            var motorcycleId = 123;
            var motorcycle = new Motorcycle();
            var command = new UpdateMotorcycleCommand { Id = motorcycleId };

            _repositoryMock.Setup(r => r.GetByIdAsync(motorcycleId)).ReturnsAsync(motorcycle);

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _mapperMock.Verify(m => m.Map(command, motorcycle), Times.Once);
            _repositoryMock.Verify(r => r.SaveChanges(), Times.Once);
        }

        [Fact]
        public async Task Handle_WhenMotorcycleDoesNotExist_ShouldThrowNotFoundException()
        {
            // Arrange
            var motorcycleId = -1;
            var command = new UpdateMotorcycleCommand { Id = motorcycleId };

            _repositoryMock.Setup(r => r.GetByIdAsync(motorcycleId)).ReturnsAsync((Motorcycle)null);

            // Act & Assert
            await Xunit.Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }

        
    }
}