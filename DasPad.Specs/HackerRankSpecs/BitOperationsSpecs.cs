using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.HackerRankSpecs
{
  public class BitOperationsSpecs
  {
    public bool IsPowerOfTwo(int input)
    {
      var toReturn = false;
      var beginWith = 0;
      var checker = (1 << beginWith);
      while (checker <= input)
      {
        if (input == checker)
        {
          toReturn = true;
        }
        beginWith++;
        checker = (1 << beginWith);
      }
      return toReturn;
    }

    public bool IsPowerOfTwoSmart(int input)
    {
      if (input == 0)
      {
        return false;
      }
      return (input & (input - 1)) == 0;
    }

    [Theory]
    [InlineData(32, true)]
    [InlineData(0, false)]
    [InlineData(1, true)]
    [InlineData(5, false)]
    [InlineData(6, false)]
    public void CanCheckIsPowerOfTwo(int input, bool expected)
    {
      Assert.Equal(expected, IsPowerOfTwo(input));
      Assert.Equal(expected, IsPowerOfTwoSmart(input));
    }

    public int NumberOfOnes(int input)
    {
      var beginWith = input;
      var count = 0;
      while (beginWith != 0)
      {
        count++;
        beginWith &= (beginWith - 1);
      }

      return count;
    }

    [Theory]
    [InlineData(23, 4)]
    [InlineData(2, 1)]
    [InlineData(3, 2)]
    public void CanCountNumberOfOnes(int input, int expected)
    {
      Assert.Equal(expected, NumberOfOnes(input));
    }

    public bool IsIthBitSet(int input, int i)
    {
      return (input & (1 << i)) != 0;
    }

    [Theory]
    [InlineData(3, 1, true)]
    [InlineData(2, 1, true)]
    [InlineData(6, 0, false)]
    public void CanCheckIsIthBitSet(int input, int i, bool expected)
    {
      Assert.Equal(expected, IsIthBitSet(input, i));
    }

    public ISet<string> GenerateSubsetsOfSet(string input)
    {
      var toReturn = new HashSet<string>();
      for (var i = 0; i < Math.Pow(2, input.Length); i++)
      {
        var str = "";
        for (var j = 0; j < input.Length; j++)
        {
          if ((i & (1 << j)) == 0)
          {
            str += input[j];
          }
        }
        if (str.Length > 0)
        {
          toReturn.Add(str);
        }
      }
      return toReturn;
    }

    [Fact]
    public void CanGenerateSubsetsOfSet()
    {
      var input = "ABC";
      var expected = new[]
      {
        "A",
        "B",
        "C",
        "AB",
        "ABC",
        "BC",
        "AC"
      }.OrderBy(a => a);
      var actual = GenerateSubsetsOfSet(input).OrderBy(a => a);

      Assert.Equal(expected, actual);
    }

    public long FindLargePowerOfTwo(int input)
    {
      if (input == 1)
      {
        return 0;
      }
      long power = 1;
      while (power <= input)
      {
        power <<= 1;
      }
      return power >> 1;
    }

    [Theory]
    [InlineData(32, 32)]
    [InlineData(33, 32)]
    [InlineData(64, 64)]
    public void CanFindLargePowerOfTwo(int input, long power)
    {
      Assert.Equal(power, FindLargePowerOfTwo(input));
    }
  }
}
