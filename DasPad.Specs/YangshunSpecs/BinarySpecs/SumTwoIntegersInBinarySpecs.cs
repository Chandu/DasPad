using Xunit;

namespace DasPad.Specs.YangshunSpecs.BinarySpecs
{
    public class SumTwoIntegersInBinarySpecs
    {
        //TODO: (CV): Not understood.
        //TODO: (CV) https://leetcode.com/problems/sum-of-two-integers/
        /*
         * Calculate the sum of two integers a and b, but you are not allowed to use the operator + and -.

          Example 1:

          Input: a = 1, b = 2
          Output: 3
          Example 2:

          Input: a = -2, b = 3
          Output: 1
         */
        /*
         * BIT Operations
         * ~~~~~~~~~~~~~~~~~~~~
          Set union A | B
          Set intersection A & B
          Set subtraction A & ~B
          Set negation ALL_BITS ^ A or ~A
          Set bit A |= 1 << bit
          Clear bit A &= ~(1 << bit)
          Test bit (A & 1 << bit) != 0
          Extract last bit A&-A or A&~(A-1) or x^(x&(x-1))
          Remove last bit A&(A-1)
          Get all 1-bits ~0

          "&" AND operation, for example, 2 (0010) & 7 (0111) => 2 (0010)

          "^" XOR operation, for example, 2 (0010) ^ 7 (0111) => 5 (0101)

          "~" NOT operation, for example, ~2(0010) => -3 (1101) what??? Don't get frustrated here. It's called two's complement.

          1111 is -1, in two's complement

          1110 is -2, which is ~2 + 1, ~0010 => 1101, 1101 + 1 = 1110 => 2

          1101 is -3, which is ~3 + 1
         */

        public int GetSum(int a, int b)
        {
            int c;
            while (b != 0)
            {
                c = (a & b);
                a = a ^ b;
                b = (c) << 1;
            }
            return a;
        }

        [Theory]
        [InlineData(1, 2, 3)]
        public void CanGetSum(int a, int b, int expected)
        {
            Assert.Equal(expected, GetSum(a, b));
        }
    }
}