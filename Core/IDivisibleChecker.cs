namespace DivisorWriter.Service;

public interface IDivisibleChecker
{
    bool IsDivisible(int dividend, int divisor);
}