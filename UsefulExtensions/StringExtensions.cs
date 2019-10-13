using System;
using System.Text;

namespace UsefulExtensions
{
    /// <summary>
    /// Useful String Extensions
    /// </summary>
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static void ToUpperAtIndex (this string value, int i)
        {
            char[] charArray = value.ToCharArray();
            charArray[i] = Char.ToUpper(charArray[i]);
            value = new string(charArray);
        }

        public static void ToLowerAtIndex(this string value, int i)
        {
            char[] charArray = value.ToCharArray();
            charArray[i] = Char.ToLower(charArray[i]);
            value = new string(charArray);
        }
    }
}
