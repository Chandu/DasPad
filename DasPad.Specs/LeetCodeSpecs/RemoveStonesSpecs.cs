using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class RemoveStonesSpecs
  {
    //TODO: (CV)
    //https://leetcode.com/problems/most-stones-removed-with-same-row-or-column/solution/
    public int RemoveStones(int[][] stones)
    {
      if (stones.Length == 0 || stones[0].Length <= 1)
      {
        return 0;
      }

      int N = stones.Length;

      int[][] graph = new int[N][];
      for (int i = 0; i < N; i++)
      {
        graph[i] = new int[N];
      }

        for (int i = 0; i < N; ++i)
      {
        
        for (int j = i + 1; j < N; ++j)
          if (stones[i][0] == stones[j][0] || stones[i][1] == stones[j][1])
          {
            graph[i][++graph[i][0]] = j;
            graph[j][++graph[j][0]] = i;
          }
      }

      int ans = 0;
      bool[] seen = new bool[N];
      for (int i = 0; i < N; ++i) if (!seen[i])
        {
          Stack<int> stack = new Stack<int>();
          stack.Push(i);
          seen[i] = true;
          ans--;
          while (stack.Count > 0)
          {
            int node = stack.Pop();
            ans++;
            for (int k = 1; k <= graph[node][0]; ++k)
            {
              int nei = graph[node][k];
              if (!seen[nei])
              {
                stack.Push(nei);
                seen[nei] = true;
              }
            }
          }
        }

      return ans;
    }

    [Fact]
    public void CanRemoveStones()
    {
      var input = new[]
      {
        new [] {0,0},
        new [] {0,1},
        new [] {1,0},
        new [] {1,2},
        new [] {2,1},
        new [] {2,2}
      };
      Assert.Equal(5, RemoveStones(input));
    }
  }
}
