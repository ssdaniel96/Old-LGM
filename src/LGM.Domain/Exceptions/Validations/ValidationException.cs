namespace LGM.Domain.Exceptions.Validations
{
    public sealed class ValidationException : Exception
    {
        public ValidationException(string message) : base(message)
        {

        }

    }
}
