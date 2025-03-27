namespace Volo.CodeAnnotations;

[AttributeUsage(AttributeTargets.All)]
public class UsedImplicitAttribute(ImplicitUseKindsFlags useKindFlags, ImplicitUseTargetFlags targetFlags) : Attribute
{
    public ImplicitUseKindsFlags UseKindFlags { get; private set; } = useKindFlags;
    public ImplicitUseTargetFlags TargetFlags { get; private set; } = targetFlags;

    public UsedImplicitAttribute()
        : this(ImplicitUseKindsFlags.Default, ImplicitUseTargetFlags.Default)
    {
    }

    public UsedImplicitAttribute(ImplicitUseKindsFlags useKindFlags)
        : this(useKindFlags, ImplicitUseTargetFlags.Default)
    {
    }

    public UsedImplicitAttribute(ImplicitUseTargetFlags targetFlags)
        : this(ImplicitUseKindsFlags.Default, targetFlags)
    {
    }
}