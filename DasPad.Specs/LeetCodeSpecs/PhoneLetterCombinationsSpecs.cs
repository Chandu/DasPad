using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class PhoneLetterCombinationsSpecs
  {
    private Dictionary<char, string> PhoneLettersMap = new Dictionary<char, string>()
      {
        { '2', "abc" },
        { '3', "def" },
        { '4', "ghi" },
        { '5', "jkl" },
        { '6', "mno" },
        { '7', "pqrs" },
        { '8', "tuv" },
        { '9', "wxyz" },
      };

    public IList<string> LetterCombinationsInternal(string digits, string prefix)
    {
      if (digits.Length < 1)
      {
        return Enumerable.Empty<string>().ToList();
      }

      if (digits.Length == 1)
      {
        return PhoneLettersMap[digits[0]].Select(a => prefix + a.ToString()).ToList();
      }
      return PhoneLettersMap[digits[0]].SelectMany(a => LetterCombinationsInternal(digits.Substring(1), prefix + a)).ToList();
    }

    public IList<string> LetterCombinations(string digits)
    {
      return LetterCombinationsInternal(digits, "");
    }

    [Fact]
    public void CanLetterCombinations()
    {
      var expected = new List<string>()
      {
        "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"
      };
      Assert.Equal(expected, LetterCombinations("23"));
    }
  }
}
