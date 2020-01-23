using DasPad.Specs.Models;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.TreesSpecs
{
  public class SymmetricTreeSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-easy/94/trees/627/
     * Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).

        For example, this binary tree [1,2,2,3,4,4,3] is symmetric:

            1
           / \
          2   2
         / \ / \
        3  4 4  3

        But the following [1,2,2,null,3,null,3] is not:

            1
           / \
          2   2
           \   \
           3    3

        Note:
        Bonus points if you could solve it both recursively and iteratively.
     **/

    //TIP A Simple Recursive Version
    public bool IsSymmetric(TreeNode root) =>
        root == null || IsSymmetric(root.left, root.right);

    private bool IsSymmetric(TreeNode L, TreeNode R) =>
        (L == null && R == null) ||
        (
            !(L == null || R == null) &&
            L.val == R.val &&
            IsSymmetric(L.left, R.right) &&
            IsSymmetric(L.right, R.left)
        );

    //TIP Simple but effective Iterative way to check if tree is Symmetric.
    private bool IsSymmetricIterative(TreeNode root)
    {
      var q = new Queue<TreeNode>();

      q.Enqueue(root);
      q.Enqueue(root);

      while (q.Count > 0)
      {
        var leftNode = q.Dequeue();
        var rightNode = q.Dequeue();

        if (leftNode == null && rightNode == null) continue;
        if (leftNode == null || rightNode == null) return false;

        if (leftNode.val != rightNode.val) return false;

        q.Enqueue(leftNode.left);
        q.Enqueue(rightNode.right);
        q.Enqueue(leftNode.right);
        q.Enqueue(rightNode.left);
      }
      return true;
    }

    //My initial intuitive version
    public bool IsSymmetricRecursive(TreeNode root)
    {
      if (root == null)
      {
        return true;
      }
      var leftStack = new Stack<int>();
      var rightStack = new Stack<int>();
      Traverse(root.left, leftStack, true);
      Traverse(root.right, rightStack, false);
      if (leftStack.Count != rightStack.Count)
      {
        return false;
      }
      while (leftStack.Count > 0)
      {
        if (leftStack.Pop() != rightStack.Pop())
        {
          return false;
        }
      }
      return true;
    }

    internal void Traverse(TreeNode root, Stack<int> stack, bool readLeftToRight, int level = 1)
    {
      if (root == null)
      {
        return;
      }
      else
      {
        if (readLeftToRight)
        {
          Traverse(root.left, stack, readLeftToRight, level + 1);
          stack.Push(root.val * level);
          Traverse(root.right, stack, readLeftToRight, level + 1);
        }
        else
        {
          Traverse(root.right, stack, readLeftToRight, level + 1);
          stack.Push(root.val * level);
          Traverse(root.left, stack, readLeftToRight, level + 1);
        }
      }
    }

    [Theory]
    [InlineData("1,2,2,3,4,4,3", true)]
    [InlineData("1,2,2,null,3,null,3", false)]
    [InlineData("1,2,2,2,null,2", false)]
    public void CanVerifyIsSymmetric(string tree, bool expected)
    {
      Assert.Equal(expected, IsSymmetric(tree.AsTreeNode()));
    }
  }
}
