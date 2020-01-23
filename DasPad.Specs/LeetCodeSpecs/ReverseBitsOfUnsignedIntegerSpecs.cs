using System;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
    public class ReverseBitsOfUnsignedIntegerSpecs
    {
        public uint reverseBits(uint n)
        {
            var a = n;
            var count = 0;
            var stack = new Stack<uint>();
            while (a != 0)
            {
                uint leftMost = a & 1;
                stack.Push(leftMost);
                a = a >> 1;
                count++;
            }
            uint toReturn = 0;
            var power = 0;
            while (32 - stack.Count > 0)
            {
                stack.Push(0);
            }
            while (stack.Count > 0)
            {
                var bit = stack.Pop();
                toReturn = Convert.ToUInt32(Math.Pow(2, power) * bit) + toReturn;
                power++;
            }
            return toReturn;
        }

        [Theory]
        [InlineData(43261596, 964176192)]
        public void CanReverseBits(uint input, uint expected)
        {
            Assert.Equal(expected, reverseBits(input));
        }
    }
}