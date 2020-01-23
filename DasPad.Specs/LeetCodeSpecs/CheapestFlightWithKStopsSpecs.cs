using System;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
    public class CheapestFlightWithKStopsSpecs
    {
        //TODO: (CV)
        //Dijkstra: https://leetcode.com/problems/cheapest-flights-within-k-stops/submissions/
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int K)
        {
            var flightsMap = new Dictionary<int, List<(int, int)>>(n);
            foreach (var entry in flights)
            {
                if (!flightsMap.ContainsKey(entry[0]))
                {
                    flightsMap[entry[0]] = new List<(int, int)>();
                }
                flightsMap[entry[0]].Add((entry[1], entry[2]));
            }
            var queue = new Queue<(int, int, int)>();
            queue.Enqueue((src, K, 0));
            var toReturn = Int32.MaxValue;
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node.Item2 < 0)
                {
                    continue;
                }

                if (flightsMap.ContainsKey(node.Item1))
                {
                    var dests = flightsMap[node.Item1];
                    foreach (var dest in dests)
                    {
                        var cost = node.Item3 + dest.Item2;
                        if (dest.Item1 == dst)
                        {
                            toReturn = Math.Min(toReturn, cost);
                        }
                    }
                    dests.ForEach(a => queue.Enqueue((a.Item1, node.Item2 - 1, a.Item2 + node.Item3)));
                }
            }
            return (toReturn == Int32.MaxValue) ? -1 : toReturn;
        }

        [Fact]
        public void CanFindCheapestPrice()
        {
            var flights = new int[][]
              {
          new [] {0,1,100},
          new [] {1,2,100},
          new [] {0,2,500}
              };
            Assert.Equal(200, FindCheapestPrice(3, flights, 0, 2, 1));
            Assert.Equal(500, FindCheapestPrice(3, flights, 0, 2, 0));

            flights = new int[][]{
        new[] { 0, 1, 1 },
        new[] { 0, 2, 5 },
        new[] { 1, 2, 1 },
        new[] { 2, 3, 1 }
      };
            Assert.Equal(6, FindCheapestPrice(4, flights, 0, 3, 1));
        }
    }
}