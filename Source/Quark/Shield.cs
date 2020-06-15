using System;
using System.Collections;

namespace Quark
{
    /// <summary>
    /// Helper functions to shield the methods with invalid arguments.
    /// </summary>
    public static class Shield
    {
        /// <summary>
        /// Checks if specified parameter is not null. Throws ArgumentNullException, if parameter is null.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="argument">The argument that has to be checked for null.</param>
        /// <exception cref="ArgumentNullException">Throws ArgumentNullException, if parameter is null</exception>
        public static void IsNull(string paramName, object argument)
        {
            if (null == argument)
                throw new ArgumentNullException(paramName);
        }

        /// <summary>
        /// Checks if specified value is in limits. Throws ArgumentOutOfRangeException, if value is outside limits.
        /// </summary>
        /// <param name="paramName">Name of the parameter being verified.</param>
        /// <param name="value">The value to be checked.</param>
        /// <param name="minimum">The minimum limit.</param>
        /// <param name="maximum">The maximum limit.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws ArgumentOutOfRangeException, if value is outside limits.</exception>
        public static void IsOutofRange(string paramName, double value, double minimum, double maximum)
        {
            if (value < minimum || value > maximum)
            {
                throw new ArgumentOutOfRangeException(paramName);
            }
        }

        /// <summary>
        /// Checks if specified value is valid number. Throws ArgumentException, if value is NaN.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="value">The value to be checked for.</param>
        /// <exception cref="ArgumentException">Throws ArgumentException, if value is NaN.</exception>
        public static void IsNan(string paramName, double value)
        {
            if (double.IsNaN(value))
                throw new ArgumentException(paramName);
        }

        /// <summary>Checks if specified value is valid number. Throws ArgumentException, if value is NaN or Infinity.</summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="value">The value to be checked for.</param>
        /// <exception cref="ArgumentException">Throws ArgumentException, if value is NaN or infinity</exception>
        public static void IsInvalidNumber(string paramName, double value)
        {
            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException(paramName);
        }

        /// <summary>
        /// Checks if Collection has values. Throws ArgumentException, if Collection is empty or  ArgumentNullException if collection is null.
        /// </summary>
        /// <param name="paramName">Name of the parameter.</param>
        /// <param name="collection">The collection to be checked for.</param>
        /// <exception cref="ArgumentException">Throws ArgumentException, if Collection is empty</exception>
        /// TODO Edit XML Comment Template for IsCollectionEmpty
        public static void IsCollectionEmpty(string paramName, ICollection collection)
        {
            IsNull(paramName, collection);

            if (collection.Count == 0)
                throw new ArgumentException(paramName);
        }
    }
}