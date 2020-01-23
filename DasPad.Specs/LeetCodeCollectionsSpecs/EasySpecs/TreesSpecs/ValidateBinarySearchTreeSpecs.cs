using DasPad.Specs.Models;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.TreesSpecs
{
  public class ValidateBinarySearchTreeSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-easy/94/trees/625/
     * Given a binary tree, determine if it is a valid binary search tree (BST).

      Assume a BST is defined as follows:

      The left subtree of a node contains only nodes with keys less than the node's key.
      The right subtree of a node contains only nodes with keys greater than the node's key.
      Both the left and right subtrees must also be binary search trees.

      Example 1:

          2
         / \
        1   3

      Input: [2,1,3]
      Output: true
      Example 2:

          5
         / \
        1   4
           / \
          3   6

      Input: [5,1,4,null,null,3,6]
      Output: false
      Explanation: The root node's value is 5 but its right child's value is 4.
     */

    //public bool IsValidBST(TreeNode root)
    //{
    //  if (root == null)
    //  {
    //    return true;
    //  }
    //  else
    //  {
    //    return (root.left == null || root.left.val < root.val) && (root.right == null || root.right.val > root.val) && IsValidBST(root.left) && IsValidBST(root.right);
    //  }
    //}

    //TIP - A better approach (optimized for space and time) without using stack
    public bool IsValidBST(TreeNode root)
    {
      return IsValidBST(root, long.MinValue, long.MaxValue);
    }

    public bool IsValidBST(TreeNode root, long minValue, long maxValue)
    {
      if (root == null)
      {
        return true;
      }

      if ((minValue >= (long)root.val || maxValue <= (long)root.val))
      {
        return false;
      }

      if (!IsValidBST(root.left, minValue, root.val))
      {
        return false;
      }

      return IsValidBST(root.right, root.val, maxValue);
    }

    public bool IsValidBSTUsingStackAndInOrder(TreeNode root)
    {
      var stack = new Stack<int>();
      TraverseInOrder(root, stack);
      while (stack.Count > 0)
      {
        var prev = stack.Pop();
        if (stack.Count > 0 && stack.Peek() >= prev)
        {
          return false;
        }
      }
      return true;
    }

    internal static void TraverseInOrder(TreeNode root, Stack<int> stack)
    {
      if (root != null)
      {
        TraverseInOrder(root.left, stack);
        stack.Push(root.val);
        TraverseInOrder(root.right, stack);
      }
    }

    [Theory]
    [InlineData("2,1,3", true)]
    [InlineData("5,1,4,null,null,3,6", false)]
    [InlineData("1,null,1", false)]
    [InlineData("10,5,15,null,null,6,20", false)]
    public void CanVerifyIsValidBST(string tree, bool expected)
    {
      Assert.Equal(expected, IsValidBST(tree.AsTreeNode()));
    }
  }
}
