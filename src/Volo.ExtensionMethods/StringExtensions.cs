using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

using Volo.CodeAnnotations;
using Volo.ExtensionMethods.Collections.Generic;

namespace Volo.ExtensionMethods;

public static class StringExtensions
{
    public static string EnsureEndsWith(this string str, char c)
    {
        return EnsureEndsWith(str, c, StringComparison.Ordinal);
    }

    public static string EnsureEndsWith(this string str, char c, StringComparison comparisonType)
    {
        Check.NotNull(str, nameof(str));

        return str.EndsWith(c.ToString(), comparisonType)
            ? str 
            : str + c;
    }

    public static string EnsureStartsWith(this string str, char c)
    {
        return EnsureStartsWith(str, c, StringComparison.Ordinal);
    }

    public static string EnsureStartsWith(this string str, char c, StringComparison comparisonType)
    {
        Check.NotNull(str, nameof(str));

        return str.StartsWith(c.ToString(), comparisonType)
            ? str
            : c + str;
    }

    public static bool IsNullOrEmpty(this string str)
    {
        return string.IsNullOrEmpty(str);
    }

    public static bool IsNullOrWhiteSpace(this string str)
    {
        return string.IsNullOrWhiteSpace(str);
    }

    public static string Left(this string str, int len)
    {
        Check.NotNull(str, nameof(str));

        return str.Length < len
            ? throw new ArgumentException("len argument can not be greater than given string's length!")
            : str.Substring(0, len);
    }

    public static string Right(this string str, int len)
    {
        Check.NotNull(str, nameof(str));

        return str.Length < len
            ? throw new ArgumentException("len argument can not be greater than given string's length!")
            : str.Substring(str.Length - len, len);
    }

    public static string NormalizeLineEndings(this string str)
    {
        return str.Replace("\r\n", "\n").Replace("\r", "\n").Replace("\n", Environment.NewLine);
    }

    public static int NthIndexOf(this string str, char c, int n)
    {
        Check.NotNull(str, nameof(str));

        int count = 0;
        for (int i = 0; i < str.Length; i++) 
        {
            if (str[i] != c) continue;
            
            if ((++count) == n)
            {
                return i;
            }
        }

        return -1;
    }

    public static string RemovePostfix(this string str, params string[] postfixes)
    {
        if (str.IsNullOrEmpty())
        {
            return string.Empty;
        }

        if (postfixes.IsNullOrEmpty())
        {
            return str;
        }

        foreach (var postfix in postfixes)
        {
            if (str.EndsWith(postfix))
            {
                return str.Left(str.Length - postfix.Length);
            }
        }

        return str;
    }

    public static string RemovePrefix(this string str, params string[] prefixes)
    {
        if (str.IsNullOrEmpty())
        {
            return string.Empty;
        }

        if (prefixes.IsNullOrEmpty())
        {
            return str;
        }

        foreach (var prefix in prefixes)
        {
            if (str.StartsWith(prefix))
            {
                return str.Right(str.Length - prefix.Length);
            }
        }

        return str;
    }

    public static string[] Split(this string str, string separator)
    {
        return str.Split([separator], StringSplitOptions.None);
    }

    public static string[] Split(this string str, string separator, StringSplitOptions options)
    {
        return str.Split([separator], options);
    }

    public static string[] SplitToLines(this string str)
    {
        return str.Split(Environment.NewLine);
    }

    public static string[] SplitToLines(this string str, StringSplitOptions options)
    {
        return str.Split(Environment.NewLine, options);
    }

    public static string? ToCamelCase(this string? str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            return str;
        }

        if (str.Length == 1)
        {
            return str.ToLower();
        }

        return char.ToLower(str[0]) + str.Substring(1);
    }

    public static string? ToPascalCase(this string? str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            return str;
        }

        if (str.Length == 1)
        {
            return str.ToUpper();
        }

        return char.ToUpper(str[0]) + str.Substring(1);
    }

    public static string? ToSentenceCase(this string? str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            return str;
        }

        return Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1]));
    }

    public static T ToEnum<T>(this string str)
    {
        Check.NotNull(str, nameof(str));
        return (T)Enum.Parse(typeof(T), str);
    }

    public static T ToEnum<T>(this string str, bool ignoreCase)
    {
        Check.NotNull(str, nameof(str));
        return (T)Enum.Parse(typeof(T), str, ignoreCase);
    }

    public static string ToMd5(this string str)
    {
        var inputBytes = Encoding.UTF8.GetBytes(str);
        var hashBytes = MD5.HashData(inputBytes);

        var sb = new StringBuilder();
        hashBytes.ForEach(b => sb.Append(b.ToString("X2")));

        return sb.ToString();
    }

    public static string? Truncate(this string? str, int maxLength)
    {
        if (str == null || str.Length <= maxLength)
        {
            return str;
        }

        return str.Left(maxLength);
    }

    public static string? TruncateWithPostfix(this string? str, int maxLength)
    {
        return TruncateWithPostfix(str, maxLength, "...");
    }

    public static string? TruncateWithPostfix(this string? str, int maxLength, string postfix)
    {
        if (str == null)
        {
            return null;
        }

        if (str.IsNullOrEmpty())
        {
            return string.Empty;
        }

        if (str.Length <= maxLength)
        {
            return str;
        }

        if (maxLength <= postfix.Length)
        {
            return postfix.Left(maxLength);
        }

        return str.Left(maxLength - postfix.Length) + postfix;
    }
}
