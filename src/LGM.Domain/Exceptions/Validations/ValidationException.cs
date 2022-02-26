namespace LGM.Domain.Exceptions.Validations
{
    public sealed class ValidationException : DomainException
    {
        public ValidationException(string message) : base(message)
        {

        }

    }
}
