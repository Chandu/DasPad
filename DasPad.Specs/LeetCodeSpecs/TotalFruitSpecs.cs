using System;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class TotalFruitSpecs
  {
    private class Counter
    {
      private Dictionary<int, int> dict = new Dictionary<int, int>();

      public int get(int k)
      {
        return dict.ContainsKey(k) ? dict[k] : 0;
      }

      public void add(int k, int v)
      {
        dict[k] = get(k) + v;
      }

      public int size()
      {
        return dict.Count;
      }

      public void remove(int i)
      {
        dict.Remove(i);
      }
    }

    public int TotalFruit(int[] tree)
    {
      int ans = 0, i = 0;
      Counter count = new Counter();
      for (int j = 0; j < tree.Length; ++j)
      {
        count.add(tree[j], 1);
        while (count.size() >= 3)
        {
          count.add(tree[i], -1);
          if (count.get(tree[i]) == 0)
            count.remove(tree[i]);
          i++;
        }

        ans = Math.Max(ans, j - i + 1);
      }

      return ans;

    }

    public int TotalFruitEx(params int[] tree)
    {
      return TotalFruit(tree);
    }

    [Fact]
    public void CanTotalFruit()
    {
      Assert.Equal(3, TotalFruitEx(1, 2, 1));
      Assert.Equal(3, TotalFruitEx(0, 1, 2, 2));
      Assert.Equal(4, TotalFruitEx(1, 2, 3, 2, 2));
    }
  }
}
