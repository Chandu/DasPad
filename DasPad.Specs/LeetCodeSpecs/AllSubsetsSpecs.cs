using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class AllSubsetsSpecs
  {
    //TODO: (CV)
    public IList<IList<int>> Subsets(int[] nums)
    {
      //For Lexicographic Order
      //Array.Sort(nums);
      IList<IList<int>> result = new List<IList<int>>();
      SubsetsInternal(nums, new List<int>(), result, 0);
      return result;
    }

    internal void SubsetsInternal(int[] nums, IEnumerable<int> prefix, IList<IList<int>> result, int start)
    {
      if (prefix.Count() >= nums.Length)
      {
        result.Add(prefix.ToList());
        return;
      }
      else
      {
        result.Add(prefix.ToList());
        for (var i = start; i < nums.Length; i++)
        {
          if (!prefix.Contains(nums[i]))
          {
            SubsetsInternal(nums, prefix.Union(AsArray(nums[i])), result, i + 1);
          }
        }
      }
    }

    public static T[] AsArray<T>(params T[] p)
    {
      return p;
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
    public void CanSubsets()
    {
      var input = AsArray(1, 2, 3);
      var expected = AsArray(
        AsArray(3),
        AsArray(1),
        AsArray(2),
        AsArray(1, 2, 3),
        AsArray(1, 3),
        AsArray(2, 3),
        AsArray(1, 2),
        AsArray<int>()
      );
      Assert.Equal(ListsToString(expected), ListsToString(Subsets(input)));
    }
  }
}
