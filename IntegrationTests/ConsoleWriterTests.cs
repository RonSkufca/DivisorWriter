using DivisorWriter.ConsoleWriter;
using DivisorWriter.Core;
using DivisorWriter.Service;

namespace DivisorWriter.IntegrationTests;

public class ConsoleWriterTests
{
    private readonly IWriter _writer;
    private readonly IRemainderCalculator _remainderCalculator = new RemainderCalculator();

    public ConsoleWriterTests()
    {
        _writer = new Writer(_remainderCalculator);
    }
    
    [Fact]
    public void ConsoleWriter_UsesDefaultsWhenDivisorRequestIsNull()
    {
        
    }
    
    [Fact]
    public void ConsoleWriter_WhenDividendUpperBoundSpecified_ReturnsTheNumberOfLinesSpecifiedInTheUpperBound()
    {
        
    }
    
    [Fact]
    public void ConsoleWriter_WhenDividendUpperBoundOmitted_ReturnsDefaultNumberOfLines()
    {
        
    }
}