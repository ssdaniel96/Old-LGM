using LGM.Domain.Exceptions.Validations;
using LGM.Domain.Extensions;

namespace LGM.Domain.Validators.Entities.People
{
    public static class CollaboratorValidator
    {
        public static bool IsValidName(string name) => name.IsInLengthRange(3, 50);

        public static void ValidateName(string name)
        {
            if (!IsValidName(name))
            {
                throw new ValidationException("O nome está invalido. Necessita ter entre 3 a 50 caracteres");
            }
        }
    }
}
