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
        public static bool IsNullOrEmpty(this string source)
        {
            return string.IsNullOrEmpty(source);
        }

        public static bool IsNullOrWhiteSpace(this string source)
        {
            return string.IsNullOrWhiteSpace(source);
        }

        public static string CheckNotNullOrEmpty(this string source, string parameterName)
        {
            if (source.IsNullOrWhiteSpace())
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
    }
}
