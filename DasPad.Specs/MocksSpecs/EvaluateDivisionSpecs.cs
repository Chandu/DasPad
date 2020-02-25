using System.Collections.Generic;

namespace DasPad.Specs.MocksSpecs
{
  public class EvaluateDivisionSpecs
  {
    /*
     * https://leetcode.com/problems/evaluate-division/
     * 399. Evaluate Division
        Medium

        1791

        137

        Add to List

        Share
        Equations are given in the format A / B = k, where A and B are variables represented as strings, and k is a real number (floating point number). Given some queries, return the answers. If the answer does not exist, return -1.0.

        Example:
        Given a / b = 2.0, b / c = 3.0.
        queries are: a / c = ?, b / a = ?, a / e = ?, a / a = ?, x / x = ? .
        return [6.0, 0.5, -1.0, 1.0, -1.0 ].

        The input is: vector<pair<string, string>> equations, vector<double>& values, vector<pair<string, string>> queries , where equations.size() == values.size(), and the values are positive. This represents the equations. Return vector<double>.

        According to the example above:

        equations = [ ["a", "b"], ["b", "c"] ],
        values = [2.0, 3.0],
        queries = [ ["a", "c"], ["b", "a"], ["a", "e"], ["a", "a"], ["x", "x"] ].

        The input is always valid. You may assume that evaluating the queries will result in no division by zero and there is no contradiction.
     */

    //Interesting
    public double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries)
    {
      // build undirected graph lookup
      var nodes = new Dictionary<string, Dictionary<string, double>>();

      for (int i = 0; i < equations.Count; i++)
      {
        var start = equations[i][0];
        var end = equations[i][1];

        if (!nodes.ContainsKey(start))
        {
          nodes[start] = new Dictionary<string, double>();
        }

        if (!nodes.ContainsKey(end))
        {
          nodes[end] = new Dictionary<string, double>();
        }

        var value = values[i];

        nodes[start][end] = value;
        nodes[end][start] = 1.0 / value;
      }

      var count = queries.Count;
      var result = new double[count];
      for (int i = 0; i < count; i++)
      {
        result[i] = runDFS(queries[i][0], queries[i][1], nodes);
      }

      return result;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="start"></param>
    /// <param name="end"></param>
    /// <param name="allNodes"></param>
    /// <returns></returns>
    private static double runDFS(string start, string end, Dictionary<string, Dictionary<string, double>> allNodes)
    {
      if (!allNodes.ContainsKey(start) || !allNodes.ContainsKey(end))
      {
        return -1;
      }

      if (start == end)
      {
        return 1.0;
      }

      double result = -1;
      var items = allNodes[start];

      // remove to prevent to use this node again
      allNodes.Remove(start);

      // DFS - search all children
      foreach (var child in items.Keys)
      {
        result = runDFS(child, end, allNodes);

        if (result != -1)
        {
          result *= items[child];
          break;
        }
      }

      // backtracking - add back in
      allNodes[start] = items;

      return result;
    }
  }
}
