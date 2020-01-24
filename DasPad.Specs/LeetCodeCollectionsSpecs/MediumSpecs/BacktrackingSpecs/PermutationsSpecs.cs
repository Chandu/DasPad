using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.BacktrackingSpecs
{
  public class PermutationsSpecs
  {
    /*
     * Given a collection of distinct integers, return all possible permutations.

        Example:

        Input: [1,2,3]
        Output:
        [
          [1,2,3],
          [1,3,2],
          [2,1,3],
          [2,3,1],
          [3,1,2],
          [3,2,1]
        ]
     */

    //Revisit.
    //Note:
    /*
     * Time Complexity: O(n * n!) -> the n! is for the permutations and n is coming from copying the string to result.
     * Space: O(n * n!)
     */

    public IList<IList<int>> Permute(int[] nums)
    {
      var toReturn = new List<IList<int>>();
      PermuteDfs(nums, 0, nums.Length - 1, toReturn);
      return toReturn;
    }

    public void PermuteDfs(int[] nums, int l, int r, IList<IList<int>> tracker)
    {
      if (l == r)
      {
        tracker.Add(nums.Clone() as int[]);
      }
      else
      {
        for (int i = l; i <= r; i++)
        {
          Swap(nums, l, i);
          PermuteDfs(nums, l + 1, r, tracker);
          Swap(nums, l, i);
        }
      }
    }

    public void Swap(int[] nums, int l, int r)
    {
      var temp = nums[l];
      nums[l] = nums[r];
      nums[r] = temp;
    }

    private IList<IList<int>> Permutes = new List<IList<int>>();

    public IList<IList<int>> PermuteOtherAppraoch(int[] nums)
    {
      GetPermute(new List<int>(), nums);

      return Permutes;
    }

    private void GetPermute(List<int> list, int[] nums)
    {
      List<int> tempList = null;

      if (list.Count != nums.Length)
      {
        for (int i = 0; i <= nums.Length - 1; i++)
        {
          if (!list.Contains(nums[i]))
          {
            tempList = new List<int>(list);
            tempList.Add(nums[i]);
            GetPermute(tempList, nums);
          }
        }
      }
      else
        Permutes.Add(list);
    }

    [Fact]
    public void CanPermute()
    {
      var nums = new[] { 1, 2, 3 };
      var result = PermuteOtherAppraoch(nums);
      //Assert.Equal(Permute(new[] { 1, 2, 3 }), PermuteOtherAppraoch(nums));
    }
  }
}
