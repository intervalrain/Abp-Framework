using Shouldly;

using Volo.ExtensionMethods.Collections.Generic;

namespace Volo.ExtensionMethods.Tests;

public class ObjectExtensions_Tests
{
    [Fact]
    public void As_Test()
    {
        var obj = (object)new ObjectExtensions_Tests();
        obj.As<ObjectExtensions_Tests>().ShouldNotBeNull();

        obj = null;
        obj?.As<ObjectExtensions_Tests>().ShouldBeNull();
    }

    [Fact]
    public void To_Tests()
    {
        "42".To<int>().ShouldBeOfType<int>().ShouldBe(42);
        "42".To<Int32>().ShouldBeOfType<Int32>().ShouldBe(42);

        "28173829281734".To<long>().ShouldBeOfType<long>().ShouldBe(28173829281734);
        "28173829281734".To<Int64>().ShouldBeOfType<Int64>().ShouldBe(28173829281734);

        "2.0".To<double>().ShouldBe(2.0);
        "0.2".To<double>().ShouldBe(0.2);
        (2.0).To<int>().ShouldBe(2);

        "false".To<bool>().ShouldBeOfType<bool>().ShouldBe(false);
        "true".To<bool>().ShouldBeOfType<bool>().ShouldBe(true);

        Assert.Throws<FormatException>(() => "test".To<bool>());
        Assert.Throws<FormatException>(() => "test".To<int>());
    }

    [Fact]
    public void IsIn_test()
    {
        5.IsIn(1, 3, 5, 7).ShouldBeTrue();
        6.IsIn(1, 3, 5, 7).ShouldBeFalse();

        int? number = null;
        number.IsIn(2, 3, 5).ShouldBeFalse();

        var str = "a";
        str.IsIn("a", "b", "c").ShouldBeTrue();
        str.IsIn("d", "e", "f").ShouldBeFalse();

        str = null;
        str.IsIn("a", "b", "c").ShouldBe(false);

        var primes = Primes(25).ToArray();
        23.IsIn(primes).ShouldBeTrue();
        24.IsIn(primes).ShouldBeFalse();
    }

    private static IEnumerable<int> Primes(int num)
    {
        bool[] isPrime = new bool[num + 1];
        Array.Fill(isPrime, true);
        Enumerable.Range(0, 2).ForEach(num => isPrime[num] = false);
        
        for (int i = 2; i <= num; i++)
        {
            if (!isPrime[i]) continue;
            for (int j = 2 * i; j < num; j += i)
            {
                isPrime[j] = false;
            }
        }
        for (int i = 2; i <= num; i++)
        {
            if (isPrime[i])
            {
                yield return i;
            }
        }
    }
}