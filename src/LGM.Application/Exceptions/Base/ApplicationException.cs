using LGM.Domain.Exceptions.Base;

namespace LGM.Application.Exceptions.Base;
public abstract class ApplicationException : BaseException
{
    protected ApplicationException(string message) : base(message)
    {
    }
}

