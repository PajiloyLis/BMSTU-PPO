namespace Project.Core.Exceptions;

public class PositionAlreadyExistException : Exception
{
    public PositionAlreadyExistException()
    {
    }

    public PositionAlreadyExistException(string message) : base(message)
    {
    }

    public PositionAlreadyExistException(string message, Exception inner) : base(message, inner)
    {
    }
}