using Xunit;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.TreesSpecs
{
  public class SortedArrayToBinarySearchTreeSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-easy/94/trees/631/
     * Given an array where elements are sorted in ascending order, convert it to a height balanced BST.

        For this problem, a height-balanced binary tree is defined as a binary tree in which the depth of the two subtrees of every node never differ by more than 1.

        Example:

        Given the sorted array: [-10,-3,0,5,9],

        One possible answer is: [0,-3,9,-10,null,5], which represents the following height balanced BST:

              0
             / \
           -3   9
           /   /
         -10  5
     */

    public TreeNode SortedArrayToBST(int[] nums)
    {
      if (nums == null || nums.Length < 1)
      {
        return null;
      }

      return GetRoot(nums, 0, nums.Length - 1);
    }

    public TreeNode GetRoot(int[] nums, int start, int end)
    {
      if (start > end)
      {
        return null;
      }
      int mid = start + (end - start) / 2;
      var root = new TreeNode(nums[mid]);
      var left = GetRoot(nums, start, mid - 1);
      var right = GetRoot(nums, mid + 1, end);
      root.left = left;
      root.right = right;
      return root;
    }

    [Fact]
    public void CanSortedArrayToBST()
    {
      Assert.True(new ValidateBinarySearchTreeSpecs().IsValidBST(SortedArrayToBST(AsArray(-10, -3, 0, 5, 9))));
    }
  }
}
