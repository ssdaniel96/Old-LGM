using LGM.Domain.Exceptions.Validations;

namespace LGM.Domain.Validators.Entities.People
{
    public static class SquadValidator
    {
        public static bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name)
                   && name.Length is > 2 and <= 50;
        }

        public static void ValidateName(string name)
        {
            if (!IsValidName(name))
            {
                throw new ValidationException("O nome está invalido. Necessita ter entre 3 a 50 caracteres");
            }
        }
    }
}
