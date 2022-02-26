namespace LGM.Domain.Extensions
{
    public static class StringExtensions
    {
        public static bool HasValue(this string? value) => !string.IsNullOrWhiteSpace(value);

        public static bool IsLengthGreatherThan(this string? value, int lengthOf)
        {
            return HasValue(value)
                   && value!.Length >= lengthOf;
        }

        public static bool IsInLengthRange(this string? value, int lengthOf, int lengthTo)
        {
            return IsLengthGreatherThan(value, lengthOf)
                   && value!.Length <= lengthTo;
        }
    }
}
