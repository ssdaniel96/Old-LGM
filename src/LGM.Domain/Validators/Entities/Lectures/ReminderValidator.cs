using System.ComponentModel.DataAnnotations;

namespace LGM.Domain.Validators.Entities.Lectures
{
    public static class ReminderValidator
    {
        public static bool IsValidPage(int page) => page > 0;
        public static bool IsValidChapter(int chapter) => chapter > 0;
        public static bool IsValidParagraph(int paragraph) => paragraph > 0;

        public static void Validate(int page, int chapter, int paragraph)
        {
            if (!IsValidPage(page))
                throw new ValidationException("A página não pode ser inferior a 0.");

            if (!IsValidChapter(chapter))
                throw new ValidationException("O capítulo não pode ser menor que 0.");

            if (!IsValidParagraph(paragraph))
                throw new ValidationException("O número do parágrafo não pode ser menor que 0.");
        }
    }
}
