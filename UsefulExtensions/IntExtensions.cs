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
        public static bool IsNull(this int? number)
        {
            return number == null;
        }

        public static bool IsNullOrZero(this int? number)
        {
            return number == null || number == 0;
        }

        public static bool IsZero(this int? number)
        {
            return number == 0;
        }

        public static bool IsZero(this int number)
        {
            return number == 0;
        }

        public static bool IsPositive(this int? number)
        {
            return number > 0;
        }

        public static bool IsPositive(this int number)
        {
            return number > 0;
        }

        public static bool IsNegative(this int? number)
        {
            return number < 0;
        }

        public static bool IsNegative(this int number)
        {
            return number < 0;
        }
    }
}
