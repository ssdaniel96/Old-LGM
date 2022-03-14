namespace LGM.Application.Exceptions.Validations;
public sealed class ValidationException : Base.ApplicationException
{
    public ValidationException(string message) : base(message)
    {
    }
}

