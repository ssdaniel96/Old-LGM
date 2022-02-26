using LGM.Domain.Exceptions.Validations;
using LGM.Domain.Extensions;

namespace LGM.Domain.Validators.Entities.People
{
    public static class GroupValidator
    {
        public static bool IsValidDescription(string description) => description.IsInLengthRange(3, 100);

        public static void Validate(string description)
        {
            if (!IsValidDescription(description))
            {
                throw new ValidationException("Descrição de grupo inválida! Deve ter entre 3 a 100 caracteres!");
            }
        }
    }
}
