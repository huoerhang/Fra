using System.Linq;

namespace System.Collections.Generic
{
    public static class EnumberableExtensions
    {
        public static string JoinAsString<T>(this IEnumerable<T> source, string separator)
            => string.Join(separator, source);

        public static string JoinAsString(this IEnumerable<string> source, string separator)
            => source.JoinAsString<string>(separator);

        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, bool condition, Func<T, bool> predicate)
            => condition ? source.Where(predicate) : source;

        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, bool condition, Func<T, int, bool> predicate)
            => condition ? source.Where(predicate) : source;
    }
}
