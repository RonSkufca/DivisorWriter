namespace DivisorWriterCore;

public record DivisorRequest
{
    int DividendUpperBound { get; set; }
    Dictionary<int, string> DivisorsWithMessages { get; set; }
}