using System.Diagnostics.CodeAnalysis;

namespace Volo.CodeAnnotations;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class ContractAnnotationAttribute([NotNull] string contract, bool forceFullStates) : Attribute
{
    public string Contract { get; private set; } = contract;
    public bool ForceFullStates { get; private set; } = forceFullStates;

    public ContractAnnotationAttribute([NotNull] string contract)
        : this(contract, false)
    {
    }
}