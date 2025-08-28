using DivisorWriter.Core;
using DivisorWriter.Service;
using Shouldly;

namespace DivisorWriter.CoreTests;

public class DivisibleCheckerTests
{
    private readonly IDivisibleChecker _divisibleChecker = new DivisibleChecker();

    [Fact]
    public void IsDivisible_ReturnsTrue()
    {
        var result = _divisibleChecker.IsDivisible(10, 5);
        
        result.ShouldBeTrue();
    }
    
    [Fact]
    public void IsDivisible_ReturnsFalse()
    {
        var result = _divisibleChecker.IsDivisible(9, 4);
        
        result.ShouldBeFalse();
    }
}