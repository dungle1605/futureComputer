namespace FutureComputer.Domain;

public class BusinessValidationException : Exception
{
    public BusinessValidationException(string message) : base(message) { }
}