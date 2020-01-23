using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.HackerRankSpecs
{
  public class DynamicArraySpecs
  {
    public static List<int> dynamicArray(int n, List<List<int>> queries)
    {
      var nArrays = new List<int>[n];
      for (var i = 0; i < n; i++)
      {
        nArrays[i] = new List<int>();
      }

      var toReturn = new List<int>();
      var lastAnswer = 0;
      foreach (var query in queries)
      {
        if (query.Count() != 3)
        {
          throw new ArgumentException("Invalid Query Length");
        }

        var queryType = query[0];
        var x = query[1];
        var y = query[2];
        if (queryType == 1)
        {
          var seq = (x ^ lastAnswer) % n;
          nArrays[seq].Add(y);
        }
        else if (queryType == 2)
        {
          var seq = (x ^ lastAnswer) % n;
          var seqSeq = nArrays[seq];
          var valIndex = (y % seqSeq.Count());
          lastAnswer = seqSeq[valIndex];
          Console.WriteLine(lastAnswer);
          toReturn.Add(lastAnswer);
        }
        else
        {
          throw new ArgumentException("Invalid Query Type");
        }
      }
      return toReturn;
    }

    [Fact]
    public void CanDynamicArray()
    {
      var n = 2;
      var queries = new List<List<int>>()
      {
        new List<int>() {1, 0, 5},
        new List<int>() {1, 1, 7},
        new List<int>() {1, 0, 3},
        new List<int>() {2, 1, 0},
        new List<int>() {2, 1, 1},
      };
      Assert.Equal(new List<int>() { 7, 3 }, dynamicArray(n, queries));
    }
  }
}
