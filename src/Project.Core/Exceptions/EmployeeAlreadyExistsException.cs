namespace Project.Core.Exceptions;

public class EmployeeAlreadyExistsException : Exception
{
    public EmployeeAlreadyExistsException()
    {
    }

    public EmployeeAlreadyExistsException(string message) : base(message)
    {
    }

    public EmployeeAlreadyExistsException(string message, Exception? inner) : base(message, inner)
    {
    }
}