namespace CleanArchitecture.Domain.Exceptions;

// This exception can now be used in the Handler Handle methods if a record is not found.
public class NotFoundException(string message) : Exception
{
}
