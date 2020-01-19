using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class GoodStringsFromCharsSpecs
  {
    public Dictionary<char, int> BuildCharsMap(string chars)
    {
      var toReturn = new Dictionary<char, int>();
      foreach (var c in chars)
      {
        if (!toReturn.ContainsKey(c))
        {
          toReturn[c] = 0;
        }
        toReturn[c]++;
      }
      return toReturn;
    }

    public int CountCharacters(string[] words, string chars)
    {
      var toReturn = 0;
      foreach (var word in words)
      {
        var charsMap = BuildCharsMap(chars);
        for (var i = 0; i < word.Length; i++)
        {
          var c = word[i];
          if (!charsMap.ContainsKey(c) || charsMap[c] <= 0)
          {
            break;
          }
          else
          {
            charsMap[c]--;
          }
          if (i == word.Length - 1)
          {
            toReturn += word.Length;
          }
        }
      }
      return toReturn;
    }

    [Fact]
    public void CanCountCharacters()
    {
      var input = new[] { "cat", "bt", "hat", "tree" };
      Assert.Equal(6, CountCharacters(input, "atach"));
    }
  }
}
