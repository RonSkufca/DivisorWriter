using DivisorWriter.Core;

namespace DivisorWriter.Service;

public interface IWriter
{
    WriterResponse Write(WriterRequest request);
}