using System.Globalization;

namespace Quark
{
    public static class DoubleExtensions
    {
        /// <summary>The infinity representation</summary>
        public static string Infinity_Representation = "∞";

        /// <summary>The NAN representation</summary>
        public static string NaN_Representation = "<>";

        /// <summary>The number format</summary>
        private static readonly NumberFormatInfo NumberFormat = new NumberFormatInfo();

        /// <summary>
        /// Limits number to boundaries.
        /// </summary>
        /// <param name="number">The number to be limited.</param>
        /// <param name="minimum">The minimum bound.</param>
        /// <param name="maximum">The maximum bound.</param>
        /// <returns>Boundary value if the number is out of boundaries;  otherwise same number</returns>
        public static double LimitTo(this double number, double minimum, double maximum)
        {
            if (number > maximum) number = maximum;
            else if (number < minimum) number = minimum;

            return number;
        }

        /// <summary>
        /// Determines whether the number has value.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///   <c>true</c> if the specified number has value; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasValue(this double number)
        {
            return double.IsNaN(number) == false && double.IsInfinity(number) == false;
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation .
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <param name="resolution">The number of decimal places.</param>
        /// <returns>
        /// The string representation of the numeric value
        /// </returns>
        public static string ToString(this double value, DecimalPlaces resolution)
        {
            if (double.IsNaN(value))
                return NaN_Representation;

            if (double.IsInfinity(value))
                return Infinity_Representation;

            if (resolution == DecimalPlaces.All)
                return value.ToString(CultureInfo.CurrentCulture);

            NumberFormat.NumberDecimalDigits = (int)resolution;
            return value.ToString("N", NumberFormat);
        }

        /// <summary>
        /// Converts the numeric value of this instance to its equivalent string representation (takes care of NAN and Infinity).
        /// </summary>
        /// <returns>The string representation of the value</returns>
        public static string ToDisplayString(this double value)
        {
            if (double.IsNaN(value))
                return NaN_Representation;

            if (double.IsInfinity(value))
                return Infinity_Representation;

            return value.ToString();
        }
    }

    public enum DecimalPlaces
    {
        None,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        All
    }
}