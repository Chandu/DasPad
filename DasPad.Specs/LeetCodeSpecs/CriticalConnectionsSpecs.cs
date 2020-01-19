using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class CriticalConnectionsSpecs
  {
    public class Graph : ICloneable
    {
      private Dictionary<int, HashSet<int>> adjList = new Dictionary<int, HashSet<int>>();

      public Graph(bool isDirected = true)
      {
        IsDirected = isDirected;
      }

      public bool IsDirected { get; }

      public IEnumerable<(int, int)> GetEdgesFor(int node)
      {
        if (!adjList.ContainsKey(node))
        {
          return Enumerable.Empty<(int, int)>();
        }
        return adjList[node].Select(b => (node, b));
      }

      public void AddEdge((int, int) point)
      {
        AddEdge(point.Item1, point.Item2);
      }

      public void AddEdge(int source, int destination)
      {
        EnsureNode(source);
        EnsureNode(destination);
        adjList[source].Add(destination);
        if (IsDirected)
        {
          adjList[destination].Add(source);
        }
      }

      public void RemoveEdge((int, int) point)
      {
        RemoveEdge(point.Item1, point.Item2);
      }

      public void RemoveEdge(int source, int destination)
      {
        if (adjList.ContainsKey(source))
        {
          adjList[source].Remove(destination);
        }
        if (IsDirected && adjList.ContainsKey(destination))
        {
          adjList[destination].Remove(source);
        }
      }

      public IEnumerable<int> Nodes => adjList.Keys;
      public IEnumerable<(int, int)> Edges => adjList.Keys.SelectMany(a => adjList[a].Select(b => (a, b)));

      private void EnsureNode(int node)
      {
        if (!adjList.ContainsKey(node))
        {
          adjList[node] = new HashSet<int>();
        }
      }

      public object Clone()
      {
        var toReturn = new Graph(this.IsDirected);
        foreach (var edge in this.Edges)
        {
          toReturn.AddEdge(edge.Item1, edge.Item2);
        }
        return toReturn;
      }
    }

    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections)
    {
      var graph = new Graph();
      foreach (var connection in connections)
      {
        graph.AddEdge(connection[0], connection[1]);
      }
      var points = new HashSet<(int, int)>();
      foreach (var edge in graph.Edges)
      {
        var newGraph = graph.Clone() as Graph;
        newGraph.RemoveEdge(edge);
        if (!IsGraphComplete(newGraph))
        {
          var arr = new[] { edge.Item1, edge.Item2};
          Array.Sort(arr);
          points.Add((arr[0], arr[1]));
        }
      }
      return points.Select(a => new[] { a.Item1, a.Item2 } as IList<int>).ToList();
    }

    private static bool IsGraphComplete(Graph graph)
    {
      var nodesVisitedStatus = graph.Nodes.ToDictionary(a => a, _ => false);
      var nodes = nodesVisitedStatus.Keys;
      var workQueue = new Queue<int>();
      if (nodes.Any())
      {
        workQueue.Enqueue(nodes.First());
        while (workQueue.Count > 0)
        {
          var node = workQueue.Dequeue();
          nodesVisitedStatus[node] = true;
          graph.GetEdgesFor(node).Where(a => !nodesVisitedStatus[a.Item2]).ToList().ForEach(a => workQueue.Enqueue(a.Item2));
        }
        return nodesVisitedStatus.All(a => a.Value);
      }
      return true;
    }

    public static string ListsToString(IEnumerable<IEnumerable<int>> arr)
    {
      var toReturn = "";
      foreach (var o in arr.OrderBy(a => string.Join(",", a)))
      {
        toReturn += "[";
        foreach (var i in o)
        {
          toReturn += i.ToString() + ", ";
        }
        toReturn = toReturn.Trim().TrimEnd(',') + "]";
      }
      return toReturn.Trim();
    }

    [Fact]
    public void CanCheckIfGraphIsComplete()
    {
      IList<IList<int>> connections = new[]
      {
        new [] {0,1},
        new [] {1,2},
        new [] {2,0},
        new [] {1,3}
      };
      var graph = new Graph();
      foreach (var connection in connections)
      {
        graph.AddEdge(connection[0], connection[1]);
      }
      Assert.True(IsGraphComplete(graph));
      var newGraph = graph.Clone() as Graph;
      newGraph.RemoveEdge(1, 3);
      Assert.False(IsGraphComplete(newGraph));

      newGraph = graph.Clone() as Graph;
      newGraph.RemoveEdge(2, 0);
      Assert.True(IsGraphComplete(newGraph));
    }

    [Fact]
    public void CanCriticalConnections()
    {
      IList<IList<int>> connections = new[]
      {
        new [] {0,1},
        new [] {1,2},
        new [] {2,0},
        new [] {1,3}
      };
      var actual = CriticalConnections(4, connections);
      Assert.Equal(ListsToString(new[] { new[] { 1, 3 } }), ListsToString(actual));
    }
  }
}
