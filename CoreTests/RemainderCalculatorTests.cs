using DivisorWriter.Core;
using DivisorWriter.Service;
using Shouldly;

namespace DivisorWriter.ConsoleWriterTests;

public class RemainderCalculatorTests
{
    private readonly IRemainderCalculator _remainderCalculator = new RemainderCalculator();

    [Fact]
    public void Calculate_ReturnsRemainder()
    {
        var result = _remainderCalculator.Calculate(10, 3);
        
        result.ShouldNotBe(0);
    }
}