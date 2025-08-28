namespace DivisorWriter.Core;

public record DivisorRequest
{
    public int DividendUpperBound { get; set; }
    public Dictionary<int, string> DivisorsWithMessages { get; set; }
}