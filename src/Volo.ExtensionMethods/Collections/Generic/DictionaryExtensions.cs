using System.Diagnostics;

namespace Volo.ExtensionMethods.Collections.Generic;

[DebuggerStepThrough]
public static class DictionaryExtensions
{
    internal static bool TryGetValue<T>(this IDictionary<string, object> dictionary, string key, out T? value)
    {
        if (dictionary.TryGetValue(key, out object? obj) && obj is T t)
        {
            value = t;
            return true;
        }

        value = default;
        return false;
    }

    public static TValue? GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
    {
        return dictionary.TryGetValue(key, out TValue? obj) ? obj : default;
    }

    public static TValue? GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> factory)
    {
        return dictionary.TryGetValue(key, out TValue? obj) 
           ? obj 
           : (dictionary[key] = factory(key));
    }

    public static TValue? GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> factory)
    {
        return dictionary.GetOrAdd(key, k => factory());
    }
}