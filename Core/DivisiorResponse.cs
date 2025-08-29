using System.Collections.ObjectModel;

namespace DivisorWriter.Core;

public record DivisiorResponse
{
    public ICollection<string> Messages { get; set; } = new Collection<string>();
}