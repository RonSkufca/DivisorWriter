using DivisorWriter.Service;

namespace DivisorWriter.Core;

public class DivisibleChecker : IDivisibleChecker
{
    /// <summary>
    /// The remainder operator % computes the remainder after dividing its left-hand operand by its right-hand operand
    /// </summary>
    public bool IsDivisible(int dividend, int divisor)
    {
        return (dividend % divisor == 0);
    }
}