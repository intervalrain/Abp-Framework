using Shouldly;

namespace Volo.ExtensionMethods.Tests;

public class DayOfWeekExtensions_Tests
{
    [Fact]
    public void Weekend_Weekday_Test()
    {
        DayOfWeek.Monday.IsWeekday().ShouldBeTrue();
        DayOfWeek.Monday.IsWeekend().ShouldBeFalse();

        DayOfWeek.Saturday.IsWeekday().ShouldBeFalse();
        DayOfWeek.Saturday.IsWeekend().ShouldBeTrue();

        var dateTime1 = new DateTime(2025, 3, 28);  // Friday
        var dateTime2 = new DateTime(2025, 3, 30);  // Sunday

        dateTime1.DayOfWeek.IsWeekday().ShouldBeTrue();
        dateTime1.DayOfWeek.IsWeekend().ShouldBeFalse();

        dateTime2.DayOfWeek.IsWeekday().ShouldBeFalse();
        dateTime2.DayOfWeek.IsWeekend().ShouldBeTrue();
        
    }
}