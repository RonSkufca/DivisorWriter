namespace DivisorWriter.Core;

public record WriterRequest
{
    public int DividendUpperBound { get; set; }
    public Dictionary<int, string> DivisorsWithMessages { get; set; }
}