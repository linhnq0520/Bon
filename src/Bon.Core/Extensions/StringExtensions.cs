namespace Bon.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool HasValue(this string str)
        {
            return !string.IsNullOrEmpty(str);
        }

        public static bool NullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
    }
}
