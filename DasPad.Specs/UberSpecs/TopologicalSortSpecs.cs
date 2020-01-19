using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.UberSpecs
{
  public class TopologicalSortSpecs
  {
    public class Item
    {
      public string Name { get; private set; }
      public Item[] Dependencies { get; private set; }

      public Item(string name, params Item[] dependencies)
      {
        Name = name;
        Dependencies = dependencies;
      }
    }

    //TODO: (CV) Topological Sort.
    public static IList<T> Sort<T>(IEnumerable<T> source, Func<T, IEnumerable<T>> getDependencies)
    {
      var sorted = new List<T>();
      var visited = new Dictionary<T, bool>();

      foreach (var item in source)
      {
        Visit(item, getDependencies, sorted, visited);
      }

      return sorted;
    }

    private static void Visit<T>(T item, Func<T, IEnumerable<T>> getDependencies, List<T> sorted, Dictionary<T, bool> visited)
    {
      var alreadyVisited = visited.TryGetValue(item, out bool inProcess);

      if (alreadyVisited)
      {
        if (inProcess)
        {
          throw new ArgumentException("Cyclic dependency found.");
        }
      }
      else
      {
        visited[item] = true;

        var dependencies = getDependencies(item);
        if (dependencies != null)
        {
          foreach (var dependency in dependencies)
          {
            Visit(dependency, getDependencies, sorted, visited);
          }
        }

        visited[item] = false;
        sorted.Add(item);
      }
    }

    public static string ToString(IList<Item> items)
    {
      return items.Aggregate("", (acc, cur) => acc + cur.Name + " ").Trim();
    }

    [Fact]
    public void CanCheckTopologicalSort()
    {
      var a = new Item("A");
      var c = new Item("C");
      var f = new Item("F");
      var h = new Item("H");
      var d = new Item("D", a);
      var g = new Item("G", f, h);
      var e = new Item("E", d, g);
      var b = new Item("B", c, e);

      var unsorted = new[] { a, b, c, d, e, f, g, h };

      var sorted = Sort(unsorted, x => x.Dependencies);
      Assert.Equal("A C D F H G E B", ToString(Sort(unsorted, x => x.Dependencies)));
    }
  }
}
