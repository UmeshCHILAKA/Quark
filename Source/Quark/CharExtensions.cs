using System.Globalization;

namespace Quark
{
    /// <summary>
    /// Helper class for char operations
    /// </summary>
    public static class CharExtensions
    {
        /// <summary>
        /// Returns the Unicode value of the character.
        /// </summary>
        /// <param name="character">The character that has to be converted.</param>
        /// <returns>Unicode value</returns>
        public static string ToUnicodeValue(this char character)
        {
            return string.Format(CultureInfo.InvariantCulture, "U+{0:X4}", (int)character);
        }

        /// <summary>
        /// Returns displayable value for a character.
        /// </summary>
        /// <param name="character">The character that has to be checked.</param>
        /// <returns>Displayable string for the character</returns>
        public static string ToDisplayValue(this char character)
        {
            if (char.IsControl(character) || char.IsSeparator(character) ||
                char.IsSurrogate(character))
                return ToUnicodeValue(character);

            return string.Format(CultureInfo.InvariantCulture, "{0}", character);
        }

        /// <summary>
        /// Returns the URL equivalent character.
        /// </summary>
        /// <param name="character">The character that has to be checked.</param>
        /// <returns>Character equivalent that has to be used in URL</returns>
        public static string ToUrlValue(this char character)
        {
            //TODO: Needs to be checked for  char.IsSymbol
            //TODO: Check Path.InvalidPathChars.

            if (char.IsControl(character) || char.IsSeparator(character) ||
                char.IsSurrogate(character))
                return string.Format(CultureInfo.InvariantCulture, "%{0:X2}", (int)character);

            return string.Format(CultureInfo.InvariantCulture, "{0}", character);
        }
    }
}