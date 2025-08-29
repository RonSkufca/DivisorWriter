using DivisorWriter.Core;
using DivisorWriter.Service;

namespace DivisorWriter.ConsoleWriter;

public class Writer(IDivisibleChecker divisibleChecker) : IWriter
{
    private const int DividendUpperBoundDefault = 10;
    private static readonly Dictionary<int, string> DivisorsWithMessagesDefault = new Dictionary<int, string>()
    {
        {3, "Ron"},
        {5, "Jeffery"}   
    };

    public WriterResponse Write(WriterRequest request)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }
        
        var divisorsWithMessages = GetDivisorsWithMessagesOrDefault(request);
        
        var upperBound = GetUpperBoundOrDefault(request.DividendUpperBound);
        
        var response = new WriterResponse();
        
        // Nested loops are O(n^2) which is not ideal, but it's a simple example
        for (int index = 1; index <= upperBound; index++)
        {
            foreach (var divisor in divisorsWithMessages)
            {
                if (divisibleChecker.IsDivisible(index, divisor.Key))
                {
                    Console.WriteLine(divisor.Value);
                    response.Messages.Add(divisor.Value);
                }
                else
                {
                    Console.WriteLine(index);
                    response.Messages.Add(index.ToString());
                }
            }
        }
        
        return response;
    }

    private static Dictionary<int, string> GetDivisorsWithMessagesOrDefault(WriterRequest request)
    {
        if (request.DivisorsWithMessages == null)
        {
            return DivisorsWithMessagesDefault;
        }

        if (request.DivisorsWithMessages.Count == 0)
        {
            return DivisorsWithMessagesDefault;
        }
        
        return request.DivisorsWithMessages;
    }
    
    private static int GetUpperBoundOrDefault(int dividendUpperBound)
    {
        return (dividendUpperBound == 0) ? DividendUpperBoundDefault : dividendUpperBound;
    }
}