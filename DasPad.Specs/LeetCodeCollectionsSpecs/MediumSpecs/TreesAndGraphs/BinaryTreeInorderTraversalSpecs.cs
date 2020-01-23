using DasPad.Specs.Models;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.TreesAndGraphs
{
  public class BinaryTreeInorderTraversalSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-medium/108/trees-and-graphs/786/
     * Binary Tree Inorder Traversal
      Solution
      Given a binary tree, return the inorder traversal of its nodes' values.

      Example:

      Input: [1,null,2,3]
         1
          \
           2
          /
         3

      Output: [1,3,2]
      Follow up: Recursive solution is trivial, could you do it iteratively?
     */

    public IList<int> InorderTraversal(TreeNode root)
    {
      var list = new List<int>();
      //InorderTraversalRecursive(root, list);
      InOrderTraversalIterative(root, list);
      return list;
    }

    //Revisit: Simulating a Recursive Call Behaviour with Stack.
    private void InOrderTraversalIterative(TreeNode root, IList<int> list)
    {
      var stack = new Stack<TreeNode>();
      TreeNode curr = root;
      while (curr != null || stack.Count > 0)
      {
        while (curr != null)
        {
          stack.Push(curr);
          curr = curr.left;
        }
        curr = stack.Pop();
        list.Add(curr.val);
        curr = curr.right;
      }
    }

    private void InorderTraversalRecursive(TreeNode root, IList<int> list)
    {
      if (root != null)
      {
        InorderTraversalRecursive(root.left, list);
        list.Add(root.val);
        InorderTraversalRecursive(root.right, list);
      }
    }

    [Theory]
    [InlineData("2,1,3", 1, 2, 3)]
    [InlineData("1,null,2,3", 1, 3, 2)]
    public void CanInOrderTraversal(string tree, params int[] expected)
    {
      Assert.Equal(expected, InorderTraversal(tree.AsTreeNode()));
    }
  }
}
