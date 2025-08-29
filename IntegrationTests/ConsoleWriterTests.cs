using DivisorWriter.ConsoleWriter;
using DivisorWriter.Core;
using DivisorWriter.Service;
using Shouldly;

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
    public void ConsoleWriter_HappyPath()
    {
        // Arrange
        var request = new DivisorRequest
        {
            DividendUpperBound = 10,
            DivisorsWithMessages = new Dictionary<int, string>()
            {
                {3, "Ron"},
                {5, "Jeffery"}
            }
        };
        
        // 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
        // Our total messages should be 20
        // UpperBound = 10 
        // DivisorsWithMessages = 2
        // UpperBound * DivisorsWithMessages = 20
        
        // Act
        var response = _writer.Write(request);

        // Assert
        response.ShouldNotBeNull();
        response.Messages.Count.ShouldBe(20);
        
        var numberOfTimesRonAppears = response.Messages.Count(m =>  m == "Ron");
        numberOfTimesRonAppears.ShouldBe(3);
        
        var numberOfTimesJefferyAppears = response.Messages.Count(m => m == "Jeffery");
        numberOfTimesJefferyAppears.ShouldBe(2);
    }
    
    [Fact]
    public void ConsoleWriter_ThrowsException_WhenDivisorRequestIsNull()
    {
        // Arrange
        DivisorRequest request = null;
        
        // Act
        Assert.Throws<ArgumentNullException>(() => _writer.Write(request));
    }
    

    [Fact]
    public void ConsoleWriter_WhenDividendUpperBoundOmitted_ReturnsDefaultNumberOfLines()
    {
        var request = new DivisorRequest
        {
            DividendUpperBound = 0,
            DivisorsWithMessages = new Dictionary<int, string>()
            {
                {3, "Ron"},
                {5, "Jeffery"}
            }
        };
        
        // Act
        var response = _writer.Write(request);

        // Assert
        response.ShouldNotBeNull();
        response.Messages.Count.ShouldBe(20);
        
        var numberOfTimesRonAppears = response.Messages.Count(m =>  m == "Ron");
        numberOfTimesRonAppears.ShouldBe(3);
        
        var numberOfTimesJefferyAppears = response.Messages.Count(m => m == "Jeffery");
        numberOfTimesJefferyAppears.ShouldBe(2);
    }
    
    
    [Fact]
    public void ConsoleWriter_WhenDivisorsWithMessagesOmitted_ReturnsDefaultDivisorsWithMessages()
    {
        var request = new DivisorRequest
        {
            DividendUpperBound = 10
        };
        
        // Act
        var response = _writer.Write(request);

        // Assert
        response.ShouldNotBeNull();
        response.Messages.Count.ShouldBe(20);
        
        var numberOfTimesRonAppears = response.Messages.Count(m =>  m == "Ron");
        numberOfTimesRonAppears.ShouldBe(3);
        
        var numberOfTimesJefferyAppears = response.Messages.Count(m => m == "Jeffery");
        numberOfTimesJefferyAppears.ShouldBe(2);
    }
}