using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string source, bool allowWhiteSpace = false)
        {
            if (!allowWhiteSpace)
            {
                source = source?.Trim();
            }

            return string.IsNullOrEmpty(source);
        }

        public static bool IsNullOrWhiteSpace(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }

        public static string CheckNotNullOrEmpty(this string source, string parameterName)
        {
            if (source.IsNullOrEmpty())
            {
                throw new ArgumentNullException(parameterName);
            }

            return source;
        }

        public static string CheckNotNullOrWhiteSpace(this string source, string parameterName)
        {
            if (source.IsNullOrWhiteSpace())
            {
                throw new ArgumentException(parameterName);
            }

            return source;
        }

        public static T ToEnum<T>(this string source, bool ignoreCase)
            where T : Enum
        {
            source.CheckNotNullOrEmpty(nameof(source));

            return (T)Enum.Parse(typeof(T), source, ignoreCase);
        }

        public static T ToEnum<T>(this string source)
            where T : Enum
        {
            source.CheckNotNullOrEmpty(nameof(source));

            return (T)Enum.Parse(typeof(T), source);
        }

        public static byte[] GetBytes(this string source, Encoding encoding)
        {
            source.CheckNotNullOrEmpty(nameof(source));
            encoding.CheckNotNull(nameof(encoding));

            return encoding.GetBytes(source);
        }

        public static byte[] GetBytes(this string source)
        {
            return source.GetBytes(Encoding.UTF8);
        }

        public static string ToMd5(this string source)
        {
            source.CheckNotNullOrEmpty(nameof(source));

            using (var md5 = MD5.Create())
            {
                byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                byte[] hashBytes = md5.ComputeHash(sourceBytes);

                StringBuilder sb = new StringBuilder();

                foreach (var b in hashBytes)
                {
                    sb.Append(b.ToString("X2"));
                }

                return sb.ToString();
            }
        }

        public static string[] SplitToLines(this string source, string separator)
        {
            return source.Split(Environment.NewLine);
        }

        public static string NormalizeLines(this string str)
        {
            return str.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", Environment.NewLine);
        }


        public static ReadOnlySpan<char> Left(this string source, int length)
        {
            source.CheckNotNullOrEmpty(nameof(source));

            if (source.Length < length)
            {
                throw new ArgumentException($"{nameof(length)} argument can not be bigger than string's length!");
            }

            return source.AsSpan(0, length);
        }

        public static ReadOnlySpan<char> Right(this string source,int length)
        {
            source.CheckNotNullOrEmpty(source);

            if (source.Length < length)
            {
                throw new ArgumentException($"{nameof(length)} argument can not be bigger than string's length!");
            }

            return source.AsSpan(0, length);
        }

        public static bool StartsWith(this string source,char c, StringComparison comparisonType = StringComparison.Ordinal)
        {
            if (source.IsNullOrEmpty())
            {
                return false;
            }

            char start = source[0];

            return source.StartsWith(c.ToString(), comparisonType);
        }
    }
}
