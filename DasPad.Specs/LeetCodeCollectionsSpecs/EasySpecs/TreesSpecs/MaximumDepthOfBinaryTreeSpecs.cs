using DasPad.Specs.Models;
using System;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.TreesSpecs
{
  public class MaximumDepthOfBinaryTreeSpecs
  {
    /*
     *https://leetcode.com/explore/interview/card/top-interview-questions-easy/94/trees/555/
     *Given a binary tree, find its maximum depth.

        The maximum depth is the number of nodes along the longest path from the root node down to the farthest leaf node.

        Note: A leaf is a node with no children.

        Example:

        Given binary tree [3,9,20,null,null,15,7],

            3
           / \
          9  20
            /  \
           15   7
        return its depth = 3.
     */

    public int MaxDepth(TreeNode root)
    {
      if (root == null)
      {
        return 0;
      }
      else
      {
        return 1 + Math.Max(MaxDepth(root.left), MaxDepth(root.right));
      }
    }

    [Theory]
    [InlineData("3,9,20,null,null,15,7", 3)]
    public void CanFindMaxDepth(string tree, int expected)
    {
      Assert.Equal(expected, MaxDepth(tree.ToTreeNode()));
    }
  }
}
