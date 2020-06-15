namespace Quark
{
    public static class StringExtensions
    {
        /// <summary>Limits the chars to the count.</summary>
        /// <param name="text">The text to be limited to.</param>
        /// <param name="count">The count of characters.</param>
        /// <returns>Text limited to characters</returns>
        public static string LimitChars(this string text, int count)
        {
            Shield.IsOutofRange("Count", count, 4, double.MaxValue);

            if (text.Length <= count) return text;
            return string.Concat(text.Substring(0, count - 3), "...");
        }
    }
}
