using System;
using System.Collections.Generic;
using System.Text;

namespace UsefulExtensions
{
    /// <summary>
    /// Useful Int Extensions
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        /// Indicates whether this instance is null.
        /// </summary>
        /// <param name="number">This int? instance.</param>
        /// <returns></returns>
        public static bool IsNull(this int? number)
        {
            return number == null;
        }

        /// <summary>
        /// Indicates whether this instance is null or zero.
        /// </summary>
        /// <param name="number">This int? instance.</param>
        /// <returns></returns>
        public static bool IsNullOrZero(this int? number)
        {
            return number == null || number == 0;
        }

        /// <summary>
        /// Indicates whether this instance is zero.
        /// </summary>
        /// <param name="number">This int? instance.</param>
        /// <returns></returns>
        public static bool IsZero(this int? number)
        {
            return number == 0;
        }

        /// <summary>
        /// Indicates whether this instance is zero.
        /// </summary>
        /// <param name="number">This int instance.</param>
        /// <returns></returns>
        public static bool IsZero(this int number)
        {
            return number == 0;
        }

        /// <summary>
        /// Indicates whether this instance is higher then zero.
        /// </summary>
        /// <param name="number">This int? instance.</param>
        /// <returns></returns>
        public static bool IsPositive(this int? number)
        {
            return number > 0;
        }

        /// <summary>
        /// Indicates whether this instance is higher then zero.
        /// </summary>
        /// <param name="number">This int instance.</param>
        /// <returns></returns>
        public static bool IsPositive(this int number)
        {
            return number > 0;
        }

        /// <summary>
        /// Indicates whether this instance is lower then zero.
        /// </summary>
        /// <param name="number">This int? instance.</param>
        /// <returns></returns>
        public static bool IsNegative(this int? number)
        {
            return number < 0;
        }

        /// <summary>
        /// Indicates whether this instance is lower then zero.
        /// </summary>
        /// <param name="number">This int instance.</param>
        /// <returns></returns>
        public static bool IsNegative(this int number)
        {
            return number < 0;
        }

        /// <summary>
        /// Indicates if this instance is higher than the specified lowestNumber and lower than the specified highestNumber.
        /// </summary>
        /// <param name="number">This int instance.</param>
        /// <param name="lowestNumber">The lowest number to compare.</param>
        /// <param name="highestNumber">The highest number to compare.</param>
        /// <returns></returns>
        public static bool IsBetween(this int number, int lowestNumber, int highestNumber)
        {
            return number > lowestNumber && number < highestNumber;
        }

        /// <summary>
        /// Indicates if this instance is higher than the specified lowestNumber and lower than the specified highestNumber.
        /// </summary>
        /// <param name="number">This int? instance.</param>
        /// <param name="lowestNumber">The lowest number to compare.</param>
        /// <param name="highestNumber">The highest number to compare.</param>
        /// <returns></returns>
        public static bool IsBetween(this int? number, int? lowestNumber, int? highestNumber)
        {
            return number > lowestNumber && number < highestNumber;
        }
    }
}
