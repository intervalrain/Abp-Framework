namespace Volo.CodeAnnotations;

[Flags]
public enum ImplicitUseTargetFlags
{
    Default = Itself,
    Itself = 0b01,    // 1
    Members = 0b10,   // 2
    WithMembers = Itself | Members
}