using System.Diagnostics;

namespace Volo.ExtensionMethods.Collections.Generic;

[DebuggerStepThrough]
public static class ListExtensions
{
    /// <summary>
    /// Topological Sort
    /// </summary>
    public static List<T> SortByDependencies<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> getDependencies)
        where T : notnull
    {
        var sorted = new List<T>();
        var visited = new Dictionary<T, bool>();

        source.ForEach(item => SortByDependenciesVisit(item, getDependencies, sorted, visited));
        
        return sorted;
    }

    public static void SortByDependenciesVisit<T>(T item, Func<T, IEnumerable<T>> getDependencies, List<T> sorted, Dictionary<T, bool> visited)
        where T : notnull
    {
        if (visited.TryGetValue(item, out bool inProgress))
        {
            if (inProgress) throw new ArgumentException("Cyclic dependency found! Item: " + item);
        }
        else 
        {
            visited[item] = true;

            var dependencies = getDependencies(item);
            dependencies?.ForEach(dependency => SortByDependenciesVisit(dependency, getDependencies, sorted, visited));

            visited[item] = false;
            sorted.Add(item);
        }
    }
}