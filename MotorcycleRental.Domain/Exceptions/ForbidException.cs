namespace MotorcycleRental.Domain.Exceptions;

public class ForbidException(string message="") : Exception(message)
{
}
