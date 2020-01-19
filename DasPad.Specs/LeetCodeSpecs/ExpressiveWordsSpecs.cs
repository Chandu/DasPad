using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class ExpressiveWordsSpecs
  {
    public class CharNode
    {
      public CharNode(char character)
      {
        Character = character;
      }

      public char Character { get; }
      public int Occurances { get; private set; }

      public CharNode IncrementOccurance()
      {
        Occurances++;
        return this;
      }

      public override string ToString()
      {
        return $"{Character} -> {Occurances}";
      }
    }

    public int ExpressiveWords(string S, string[] words)
    {
      if (words == null || S == null || S.Length == 0)
      {
        return 0;
      }
      var sourceMap = new List<CharNode>();

      foreach (var c in S)
      {
        if (!sourceMap.Any())
        {
          sourceMap.Add(new CharNode(c).IncrementOccurance());
        }
        else
        {
          if (sourceMap[sourceMap.Count() - 1].Character != c)
          {
            sourceMap.Add(new CharNode(c).IncrementOccurance());
          }
          else
          {
            sourceMap[sourceMap.Count() - 1].IncrementOccurance();
          }
        }
      }

      return words.Where(a => a.Length <= S.Length).Aggregate(0, (acc, cur) => IsExpressive(cur, sourceMap) ? (acc + 1) : acc);
    }

    private bool IsExpressive(string target, List<CharNode> sourceMap)
    {
      var targetMap = new List<CharNode>();
      foreach (var c in target)
      {
        if (!targetMap.Any())
        {
          targetMap.Add(new CharNode(c).IncrementOccurance());
        }
        else
        {
          if (targetMap[targetMap.Count() - 1].Character != c)
          {
            targetMap.Add(new CharNode(c).IncrementOccurance());
          }
          else
          {
            targetMap[targetMap.Count() - 1].IncrementOccurance();
          }
        }
      }
      if (targetMap.Count() != sourceMap.Count())
      {
        return false;
      }
      for (var i = 0; i < targetMap.Count(); i++)
      {
        if (sourceMap[i].Character != targetMap[i].Character)
        {
          return false;
        }
        var occurDelta = sourceMap[i].Occurances - targetMap[i].Occurances;
        if(occurDelta < 0)
        {
          return false;
        }
        else if(occurDelta != 0 && sourceMap[i].Occurances < 3)
        {
          return false;
        }
          
      }
      return true;
    }

    [Fact]
    public void CanExpressiveWords()
    {
      Assert.Equal(1, ExpressiveWords("heeellooo", new[] { "hello", "hi", "helo" }));
      Assert.Equal(0, ExpressiveWords("aaa", new[] { "aaaa"}));
    }
  }
}
