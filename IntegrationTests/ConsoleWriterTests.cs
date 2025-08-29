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
        var request = new WriterRequest
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
    
    /// <summary>
    /// CAUTION: This test takes a long time to run. 
    /// It's only here to demonstrate how the code scales to large numbers.
    /// And to test the upperbound functionality.
    /// </summary>
    [Fact]
    public void ConsoleWriter_TestScalingToLargeNumbers()
    {
        // Arrange
        var request = new WriterRequest
        {
            DividendUpperBound = 10000000,
            DivisorsWithMessages = new Dictionary<int, string>()
            {
                {3, "Ron"},
                {5, "Jeffery"},
                {6, "Joe"}
            }
        };

        // Our total messages should be 30000000
        // UpperBound = 10000000 
        // DivisorsWithMessages = 3
        // UpperBound * DivisorsWithMessages = 30000000
        
        // Act
        var response = _writer.Write(request);

        // Assert
        response.ShouldNotBeNull();
        response.Messages.Count.ShouldBe(30000000);
        
        var numberOfTimesRonAppears = response.Messages.Count(m =>  m == "Ron");
        numberOfTimesRonAppears.ShouldBe(3333333);
        
        var numberOfTimesJefferyAppears = response.Messages.Count(m => m == "Jeffery");
        numberOfTimesJefferyAppears.ShouldBe(2000000);
        
        var numberOfTimesJoeAppears = response.Messages.Count(m => m == "Joe");
        numberOfTimesJoeAppears.ShouldBe(1666666);
    }
    
    [Fact]
    public void ConsoleWriter_ThrowsException_WhenDivisorRequestIsNull()
    {
        // Arrange
        WriterRequest request = null;
        
        // Act
        Assert.Throws<ArgumentNullException>(() => _writer.Write(request));
    }
    

    [Fact]
    public void ConsoleWriter_WhenDividendUpperBoundOmitted_ReturnsDefaultNumberOfLines()
    {
        var request = new WriterRequest
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
        var request = new WriterRequest
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