using DivisorWriter.Core;

namespace DivisorWriter.Service;

public interface IWriter
{
    void Write(DivisorRequest request);
}