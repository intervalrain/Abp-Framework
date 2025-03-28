using Shouldly;

namespace Volo.ExtensionMethods.Tests;

public class ComparableExtensions_Tests
{
    [Fact]
    public void IsBetween_Test()
    {
        var number = 5;
        number.IsBetween(1, 10).ShouldBeTrue();
        number.IsBetween(1, 5).ShouldBeTrue();
        number.IsBetween(5, 10).ShouldBeTrue();
        number.IsBetween(10, 20).ShouldBeFalse();

        var dateTime = new DateTime(2025, 3, 28, 12, 17, 0, DateTimeKind.Unspecified);
        dateTime.IsBetween(new DateTime(2024, 1, 1), new DateTime(2025, 1, 1)).ShouldBeFalse();
        dateTime.IsBetween(new DateTime(2025, 1, 1), new DateTime(2026, 1, 1)).ShouldBeTrue();
        dateTime.IsBetween(new DateTime(2026, 1, 1), new DateTime(2027, 1, 1)).ShouldBeFalse();
    }
}