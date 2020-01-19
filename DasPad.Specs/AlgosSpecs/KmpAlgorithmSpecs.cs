using DasPad.Algos;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.AlgosSpecs
{
  public class KmpAlgorithmSpecs
  {
    public static IEnumerable<object[]> GetLpsTheoryData()
    {
      return new[]
      {
        new object[]
        {
          "", new int[] { }
        },
        new object[]
        {
          "ABCABC", new int[] { 0, 0, 0, 1, 2, 3 }
        },
        new object[] { "AABAACAABAA", new int[] { 0, 1, 0, 1, 2, 0, 1, 2, 3, 4, 5 } },
        new object[] { "AAACAAAAAC", new int[] {0, 1, 2, 0, 1, 2, 3, 3, 3, 4} },
        new object[] { "AAABAAA", new int[] {0, 1, 2, 0, 1, 2, 3}
  },
      };
    }

    [Theory]
    [MemberData(nameof(GetLpsTheoryData))]
    public void CreateLpsTheory(string input, int[] expectedLps)
    {
      Assert.Equal(KmpAlgorithm.CreateLps(input), expectedLps);
    }

    public static IEnumerable<object[]> GetKmpTheoryData()
    {
      return new[]
      {
        new object[] {"CHANDU", "AND", 2 },
        new object[] {"CHANDU", "CH", 0 },
        new object[] {"CHANDU", "Z", -1 },
        new object[] {"CHANDU", "", -1 },
      };
    }

    [Theory]
    [MemberData(nameof(GetKmpTheoryData))]
    public void FindPatternIndexTheory(string input, string pattern, int expectedIndex)
    {
      Assert.Equal(expectedIndex, KmpAlgorithm.FindPatternIndex(input, pattern));
    }
  }
}
