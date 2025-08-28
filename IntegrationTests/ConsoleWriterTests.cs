using DivisorWriter.ConsoleWriter;
using DivisorWriter.Core;
using DivisorWriter.Service;

namespace DivisorWriter.IntegrationTests;

public class ConsoleWriterTests
{
    private readonly IWriter _writer;
    private readonly IDivisibleChecker _divisibleChecker = new DivisibleChecker();

    public ConsoleWriterTests()
    {
        _writer = new Writer(_divisibleChecker);
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