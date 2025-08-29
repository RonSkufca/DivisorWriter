using System.Collections.ObjectModel;

namespace DivisorWriter.Core;

public record WriterResponse
{
    public ICollection<string> Messages { get; set; } = new Collection<string>();
}