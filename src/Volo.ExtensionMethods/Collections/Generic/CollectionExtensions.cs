using System.Diagnostics;
using JetBrains.Annotations;
using Volo.CodeAnnotations;

namespace Volo.ExtensionMethods.Collections.Generic;

[DebuggerStepThrough]
public static class CollectionExtensions
{
    public static bool IsNullOrEmpty<T>([CanBeNull] this ICollection<T> source)
    {
        return source == null || source.Count <= 0;
    }

    public static bool AddIfNotContains<T>([NotNull] this ICollection<T> source, T item)
    {
        Check.NotNull(source, nameof(source));

        if (source.Contains(item))
        {
            return false;
        }

        source.Add(item);
        return true;
    }

}