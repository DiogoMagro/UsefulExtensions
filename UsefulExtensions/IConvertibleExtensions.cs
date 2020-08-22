using System;
using System.Collections.Generic;
using System.Text;

namespace UsefulExtensions
{
    /// <summary>
    /// Useful IConvertible Extensions
    /// </summary>
    public static class IConvertibleExtensions
    {
        /// <summary>
        /// Converts the current IConvertible value to the specified type.
        /// </summary>
        /// <typeparam name="T">The type to convert.</typeparam>
        /// <param name="value">This IConvertible object instance.</param>
        /// <returns></returns>
        public static T ConvertTo<T>(this IConvertible value)
        {
            return (T) Convert.ChangeType(value, typeof(T));
        }
    }
}
