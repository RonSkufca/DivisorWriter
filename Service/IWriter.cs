using DivisorWriter.Core;

namespace DivisorWriter.Service;

public interface IWriter
{
    DivisiorResponse Write(DivisorRequest request);
}