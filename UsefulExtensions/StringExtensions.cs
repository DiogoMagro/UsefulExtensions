using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace UsefulExtensions
{
    /// <summary>
    /// Useful String Extensions
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Indicates whether this instance is null or an empty string.
        /// </summary>
        /// <param name="value">This string instance.</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Indicates whether this instance is null, empty, or consists only of white-space characters.
        /// </summary>
        /// <param name="value">This string instance.</param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Returns a copy of this string converted to uppercase at a specified index.
        /// </summary>
        /// <param name="value">This string instance.</param>
        /// <param name="index">The index to uppercase.</param>
        /// <returns></returns>
        public static string ToUpperAtIndex(this string value, int index)
        {
            char[] charArray = value.ToCharArray();
            charArray[index] = Char.ToUpper(charArray[index]);
            return new string(charArray);
        }

        /// <summary>
        /// Returns a copy of this string converted to lowercase at a specified index.
        /// </summary>
        /// <param name="value">This string instance.</param>
        /// <param name="index">The index to lowercase.</param>
        /// <returns></returns>
        public static string ToLowerAtIndex(this string value, int index)
        {
            char[] charArray = value.ToCharArray();
            charArray[index] = Char.ToLower(charArray[index]);
            return new string(charArray);
        }

        /// <summary>
        /// Convert this string to the equivalent integer.
        /// </summary>
        /// <param name="value">This string instance.</param>
        /// <param name="throwExceptionIfFailed">The bool value that indicates if should or not return exception in case of parse fails.</param>
        /// <returns></returns>
        public static int ToInt(this string value, bool throwExceptionIfFailed = false)
        {
            int result;
            if (!int.TryParse(value, out result) && throwExceptionIfFailed)
                throw new FormatException(string.Format("'{0}' cannot be converted as int", value));
            return result;
        }

        /// <summary>
        /// Returns the string between the specified strStart and strEnd. 
        /// Returns an empty string whether strStart or strEnd is not contained in the original string.
        /// </summary>
        /// <param name="value">This string instance.</param>
        /// <param name="strStart">The start string.</param>
        /// <param name="strEnd">The end string.</param>
        /// <returns></returns>
        public static string GetBetween(this string value, string strStart, string strEnd)
        {
            int Start, End;
            if (value.Contains(strStart) && value.Contains(strEnd))
            {
                Start = value.IndexOf(strStart, 0) + strStart.Length;
                End = value.IndexOf(strEnd, Start);
                return value.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// Returns the string between the specified indexStart and indexEnd.
        /// </summary>
        /// <param name="value">This string instance.</param>
        /// <param name="indexStart">The start index.</param>
        /// <param name="indexEnd">The end index.</param>
        /// <returns></returns>
        public static string GetBetween(this string value, int indexStart, int indexEnd)
        {
            indexStart += 1;
            return value.Substring(indexStart, indexEnd - indexStart);
        }

        /// <summary>
        /// Removes all leading and trailing white-space characters from the current string object. 
        /// In case the specified ignoreIfNull value be true this function will ignore null strings.
        /// </summary>
        /// <param name="value">This string instance.</param>
        /// <param name="allowNull">The bool value that indicates if null strings will be ignored.</param>
        /// <returns></returns>
        public static string Trim(this string value, bool ignoreIfNull)
        {
            if (ignoreIfNull)
            {
                if (value != null)
                    return value.Trim();
                else
                    return value;
            }
            return value.Trim();
        }

        /// <summary>
        /// Returns a new string in which the first occurrence of a specified 'search' string is replaced with a specified 'replace' string.
        /// </summary>
        /// <param name="value">This string instance.</param>
        /// <param name="search">The string to replace.</param>
        /// <param name="replace">The string that will replace the specified 'search' string.</param>
        /// <returns></returns>
        public static string ReplaceFirst(this string value, string search, string replace)
        {
            int pos = value.IndexOf(search);

            if (pos < 0)
                return value;

            return value.Substring(0, pos) + replace + value.Substring(pos + search.Length);
        }


        /// <summary>
        /// Returns a new string in which the last occurrence of a specified 'search' string is replaced with a specified 'replace' string.
        /// </summary>
        /// <param name="value">This string instance.</param>
        /// <param name="search">The string to replace.</param>
        /// <param name="replace">The string that will replace the specified 'search' string.</param>
        /// <returns></returns>
        public static string ReplaceLast(this string value, string search, string replace)
        {
            int place = value.LastIndexOf(search);

            if (place == -1)
                return value;

            return value.Remove(place, search.Length).Insert(place, replace);
        }

        /// <summary>
        /// Returns a new string in which the first occurrence of a specified 'strToRemove' string is removed.
        /// </summary>
        /// <param name="value">This string instace.</param>
        /// <param name="strToRemove">The string to remove.</param>
        /// <returns></returns>
        public static string RemoveFirst(this string value, string strToRemove)
        {
            int pos = value.IndexOf(strToRemove);

            if (pos < 0)
                return value;

            return value.Substring(0, pos) + value.Substring(pos + strToRemove.Length);
        }

        /// <summary>
        /// Returns a new string in which the last occurrence of a specified 'strToRemove' string is removed.
        /// </summary>
        /// <param name="value">This string instace.</param>
        /// <param name="strToRemove">The string to remove.</param>
        /// <returns></returns>
        public static string RemoveLast(this string value, string strToRemove)
        {
            int place = value.LastIndexOf(strToRemove);

            if (place == -1)
                return value;

            return value.Remove(place, strToRemove.Length);
        }

        /// <summary>
        /// Indicates if this string instance containes any number.
        /// </summary>
        /// <param name="value">This string instance.</param>
        /// <returns></returns>
        public static bool HasNumber(this string value)
        {
            return !value.IsNullOrWhiteSpace() && value.Any(x => Char.IsDigit(x));
        }

        /// <summary>
        /// Returns a copy of the this string without diacritics.
        /// </summary>
        /// <param name="value">This string instance.</param>
        /// <returns></returns>
        static string RemoveDiacritics(this string value)
        {
            return  string.Concat(value.Normalize(NormalizationForm.FormD).Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark))
                            .Normalize(NormalizationForm.FormC);
        }

        /// <summary>
        /// Splits this string into substrings. You can specify whether the substrings include empty array elements.
        /// </summary>
        /// <param name="value">This string instance.</param>
        /// <param name="separator">The string to use as separator.</param>
        /// <param name="options">The options to split.</param>
        /// <returns></returns>
        static string[] Split(this string value, string separator, StringSplitOptions options = StringSplitOptions.None)
        {
            return value.Split(new string[] { separator }, options);
        }
    }
}
