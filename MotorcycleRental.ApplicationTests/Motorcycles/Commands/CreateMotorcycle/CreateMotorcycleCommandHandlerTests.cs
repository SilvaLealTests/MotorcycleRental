using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using MotorcycleRental.Application.Motorcycles.Commands.CreateMotorcycle;
using MotorcycleRental.Domain.Entities;
using MotorcycleRental.Infrastructure.Repositories;
using Xunit;

namespace MotorcycleRental.ApplicationTests.Motorcycles.Commands.CreateMotorcycle;

public class CreateMotorcycleCommandHandlerTests
{
    private readonly Mock<IMotorcyclesRepository> _repositoryMock;
    private readonly Mock<ILogger<CreateMotorcycleCommandHandler>> _loggerMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly CreateMotorcycleCommandHandler _handler;

    public CreateMotorcycleCommandHandlerTests()
    {
        _repositoryMock = new Mock<IMotorcyclesRepository>();
        _loggerMock = new Mock<ILogger<CreateMotorcycleCommandHandler>>();
        _mapperMock = new Mock<IMapper>();
        _handler = new CreateMotorcycleCommandHandler(_repositoryMock.Object, _loggerMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task Handle_ValidCommand_ShouldCreateMotorcycle()
    {
        // Arrange
        var command = new CreateMotorcycleCommand { Year = 2024,
            Model = 2021, LicensePlate = "ABC-1234", Status = "A" };
        var motorcycle = new Motorcycle();
        _mapperMock.Setup(m => m.Map<Motorcycle>(It.IsAny<CreateMotorcycleCommand>()))
                   .Returns(motorcycle);

        _repositoryMock.Setup(r => r.Create(It.IsAny<Motorcycle>()))
                       .ReturnsAsync(1); // Assume 1 is the ID generated for the motorcycle

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        _mapperMock.Verify(m => m.Map<Motorcycle>(command), Times.Once);
        _repositoryMock.Verify(r => r.Create(motorcycle), Times.Once);
        Xunit.Assert.Equal(1, result);
    }

    [Fact]
    public async Task Handle_ValidCommand_ShouldLogInformation()
    {
        // Arrange
        var command = new CreateMotorcycleCommand();
        _mapperMock.Setup(m => m.Map<Motorcycle>(It.IsAny<CreateMotorcycleCommand>()))
                   .Returns(new Motorcycle());
        _repositoryMock.Setup(r => r.Create(It.IsAny<Motorcycle>()))
                       .ReturnsAsync(1);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        _loggerMock.Verify(
            x => x.Log(
                LogLevel.Information,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Creating a new motorcycle")),
                It.IsAny<Exception>(),
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
    }



}