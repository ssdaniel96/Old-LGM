using LGM.Domain.Exceptions.Validations;
using LGM.Domain.Extensions;

namespace LGM.Domain.Validators.Entities.Books
{
    public static class BookValidator
    {
        public static bool IsValidAuthor(string author) => author.IsInLengthRange(3, 50);
        public static bool IsValidTitle(string title) => title.IsInLengthRange(3, 100);
        public static bool IsValidTotalPages(int totalPages) => totalPages > 0;
        public static bool IsValidTotalChapters(int totalChapters) => totalChapters > 0;

        public static bool IsValidUri(string? uri)
        {
            if (uri == null) return true;

            try
            {
                _ = new Uri(uri);
            }
            catch
            {
                return false;
            }

            return true;
        }

        public static void Validate(string author, string title, int totalPages, int totalChapters, string? uri)
        {
            if (!IsValidAuthor(author))
                throw new ValidationException("Autor está inválido! Necessita ter entre 3 a 50 caracteres!");

            if (!IsValidTitle(title))
                throw new ValidationException("Título está inválido! Necessita ter entre 3 a 100 caracteres!");

            if (!IsValidTotalPages(totalPages))
                throw new ValidationException("O total de páginas deve ser superior a 0!");

            if (!IsValidTotalChapters(totalChapters))
                throw new ValidationException("O total de capítulos deve ser superior a 0!");

            if (!IsValidUri(uri))
                throw new ValidationException("O link para o livro está inválido!");
        }


    }
}
