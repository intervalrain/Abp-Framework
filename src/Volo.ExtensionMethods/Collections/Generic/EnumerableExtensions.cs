using System.Diagnostics;

namespace Volo.ExtensionMethods.Collections.Generic;

[DebuggerStepThrough]
public static class EnumerableExtensions
{
    public static string Join(this IEnumerable<string> source, string separator)
    {
        return string.Join(separator, source);
    }

    public static string Join<T>(this IEnumerable<T> source, string separator)
    {
        return string.Join(separator, source);
    }

    public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, bool condition, Func<T, bool> predicate)
    {
        return condition
            ? source.Where(predicate)
            : source;
    }

    public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> source, bool condition, Func<T, int, bool> predicate)
    {
        return condition
            ? source.Where(predicate)
            : source;
    }

    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (var item in source)
        {
            action(item);
        }
    }
}