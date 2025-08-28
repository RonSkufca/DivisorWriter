using DivisorWriter.Service;

namespace DivisorWriter.ConsoleWriter;

public class Writer : IWriter
{
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
}