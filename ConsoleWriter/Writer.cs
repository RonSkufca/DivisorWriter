using DivisorWriter.Core;
using DivisorWriter.Service;

namespace DivisorWriter.ConsoleWriter;

public class Writer(IRemainderCalculator remainderCalculator) : IWriter
{
    private readonly IRemainderCalculator _remainderCalculator = remainderCalculator;
    private const int DividendUpperBoundDefault = 10;
    private static readonly Dictionary<int, string> DivisorsWithMessagesDefault = new Dictionary<int, string>()
    {
        {3, "Ron"},
        {5, "Jeffery"}   
    };

    public void Write()
    {
        for (int index = 1; index < 100; index++)
        {
            if (index % 3 == 0 && index % 5 == 0)
            {
                Console.WriteLine("Ron & Jeffery");
            }
            else if (index % 3 == 0)
            {
                Console.WriteLine("Ron");
            }
            else if (index % 5 == 0)
            {
                Console.WriteLine("Jeffery");
            }
            else
            {
                Console.WriteLine(index);
            }
        }
    }

    public void Write(DivisorRequest request)
    {
        var divisorsWithMessages = GetDivisorsWithMessagesOrDefault(request);
        
        var upperBound = GetUpperBoundOrDefault(request.DividendUpperBound);
        
        for (int index = 1; index < upperBound; index++)
        {
            if (index % 3 == 0 && index % 5 == 0)
            {
                Console.WriteLine("Ron & Jeffery");
            }
            else if (index % 3 == 0)
            {
                Console.WriteLine("Ron");
            }
            else if (index % 5 == 0)
            {
                Console.WriteLine("Jeffery");
            }
            else
            {
                Console.WriteLine(index);
            }
        }
    }

    private static Dictionary<int, string> GetDivisorsWithMessagesOrDefault(DivisorRequest request)
    {
        if (request == null)
        {
            return DivisorsWithMessagesDefault;
        }

        if (request.DivisorsWithMessages == null)
        {
            return DivisorsWithMessagesDefault;
        }

        if (!request.DivisorsWithMessages.Any())
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