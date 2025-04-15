namespace Project.Core.Exceptions;

public class CompanyAlreadyExistsException : Exception
{
    public CompanyAlreadyExistsException()
    {
    }

    public CompanyAlreadyExistsException(string message) : base(message)
    {
    }

    public CompanyAlreadyExistsException(string message, Exception? inner) : base(message, inner)
    {
    }
}