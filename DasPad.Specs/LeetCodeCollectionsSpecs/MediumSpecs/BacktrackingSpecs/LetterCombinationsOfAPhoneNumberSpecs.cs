using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.BacktrackingSpecs
{
  public class LetterCombinationsOfAPhoneNumberSpecs
  {
    /*
     * Given a string containing digits from 2-9 inclusive, return all possible letter combinations that the number could represent.

      A mapping of digit to letters (just like on the telephone buttons) is given below. Note that 1 does not map to any letters.

      Example:

      Input: "23"
      Output: ["ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"].
      Note:

      Although the above answer is in lexicographical order, your answer could be in any order you want.
     * */

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

    [Theory]
    [InlineData("23", "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf")]
    public void CanLetterCombinationsInternal(string digits, params string[] expected)
    {
      Assert.Equal(expected, LetterCombinations(digits));
    }
  }
}
