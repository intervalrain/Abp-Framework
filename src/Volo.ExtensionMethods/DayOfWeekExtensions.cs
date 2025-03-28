namespace Volo.ExtensionMethods;

public static class DayOfWeekExtensions
{
    public static bool IsWeekend(this DayOfWeek dayOfWeek)
    {
        return dayOfWeek.IsIn(DayOfWeek.Saturday, DayOfWeek.Sunday);
    }

    public static bool IsWeekday(this DayOfWeek dayOfWeek)
    {
        return !IsWeekend(dayOfWeek);
    }
}