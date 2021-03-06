﻿using System;
using System.Globalization;

namespace Quark
{
    public static class StringExtensions
    {
        /// <summary>Limits the input string to the count.</summary>
        /// <param name="text">The text to be limited to.</param>
        /// <param name="count">The count of characters.</param>
        /// <returns>Text (input string) limited to characters</returns>
        public static string LimitChars(this string text, int count)
        {
            Shield.IsOutofRange("Count", count, 4, double.MaxValue);

            if (text.Length <= count) return text;
            return string.Concat(text.Substring(0, count - 3), "...");
        }

        /// <summary>Gets the double from string.</summary>
        /// <param name="number">The number in string format.</param>
        /// <returns>floating point number, NaN if number is invalid</returns>
        public static double GetDouble(this string number)
        {
            return number.GetDouble(NumberStyles.Any);
        }

        /// <summary>Gets the double from string.</summary>
        /// <param name="number">The number in string format.</param>
        /// <param name="styles">The number style of numeric string.</param>
        /// <returns>floating point number, NaN if number is invalid</returns>
        public static double GetDouble(this string number, NumberStyles styles)
        {
            double doubleValue = double.NaN;
            try
            {
                doubleValue = double.Parse(number, styles, CultureInfo.CurrentCulture);
            }
            catch
            {
                doubleValue = double.Parse(number, styles, CultureInfo.InvariantCulture);
            }
            return doubleValue;
        }

        /// <summary>
        /// Removes the empty lines at end from input string.
        /// </summary>
        /// <param name="data">Data in which empty lines have to be removed at end.</param>
        /// <returns>New string removing empty lines at end of string</returns>
        public static string RemoveEmptyLinesAtEnd(this string data)
        {
            Shield.IsNull("data", data);
            return data.TrimEnd(Environment.NewLine.ToCharArray());
        }

        /// <summary>
        /// Removes the empty line at end from input string.
        /// </summary>
        /// <param name="data">Data in which new line has to be removed at end.</param>
        /// <returns>New string removing empty line at end of string</returns>
        public static string RemoveEmptyLineAtEnd(this string data)
        {
            Shield.IsNull("data", data);

            if (data.EndsWith(Environment.NewLine))
            {
                data = data.Remove(data.Length - Environment.NewLine.Length);
            }
            return data;
        }
    }
}