namespace Quark
{
    public static class DoubleExtensions
    {
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
    }
}