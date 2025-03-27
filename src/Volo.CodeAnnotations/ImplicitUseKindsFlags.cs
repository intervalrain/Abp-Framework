namespace Volo.CodeAnnotations;

[Flags]
public enum ImplicitUseKindsFlags
{
    Default = Access | Assign | InstantiatedWithFixedConstructorSignature,
    Access = 0b0001,                                     // 1
    Assign = 0b0010,                                     // 2
    InstantiatedWithFixedConstructorSignature = 0b0100,  // 4
    InstantiatedNoFixedConstructorSignature = 0b1000     // 8
}