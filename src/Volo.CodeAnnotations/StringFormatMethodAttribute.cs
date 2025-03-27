using JetBrains.Annotations;

namespace Volo.CodeAnnotations;

[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Delegate)]
public sealed class StringFormatMethodAttribute([NotNull] string formatParameterName) : Attribute
{
    [NotNull]
    public string FormatParameterName { get; private set; } = formatParameterName;
}