using DasPad.Specs.Models;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.TreesAndGraphs
{
  public class KthSmallestElementInABSTSpecs
  {
    /*
     * Given a binary search tree, write a function kthSmallest to find the kth smallest element in it.

        Note:
        You may assume k is always valid, 1 ≤ k ≤ BST's total elements.

        Example 1:

        Input: root = [3,1,4,null,2], k = 1
           3
          / \
         1   4
          \
           2
        Output: 1
        Example 2:

        Input: root = [5,3,6,2,4,null,null,1], k = 3
               5
              / \
             3   6
            / \
           2   4
          /
         1
        Output: 3
        Follow up:
        What if the BST is modified (insert/delete operations) often and you need to find the kth smallest frequently? How would you optimize the kthSmallest routine?
     */
    //Note: For the Follow up,
    //one way is to add a field to the tree node which containst he numbers o nodes including it self with it being root (vasically subtree)
    /*
     *
     */

    public int KthSmallest(TreeNode root, int k)
    {
      //return KthSmallestUsingInOrder(root, k);
      return KthSmallestUsingStackInsteadOfRecursion(root, k);
    }

    //TIP: Another example of using stack implicitly instead of Recursion.
    //Note: LeetCode Article: https://leetcode.com/articles/kth-smallest-element-in-a-bst/
    private int KthSmallestUsingStackInsteadOfRecursion(TreeNode root, int k)
    {
      var stack = new Stack<TreeNode>();
      var curr = root;
      var list = new List<int>();
      //Note: For simulating a stack this is the usual pattern I have observed and makes sense. basically check if the curr element is null or if the existing stack has elements.
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

      var inordered = list.ToArray();
      return inordered[k - 1];
    }

    private void BuildListFromTree(TreeNode node, List<int> list, int k)
    {
      if (node != null && list.Count < k)
      {
        BuildListFromTree(node.left, list, k);
        list.Add(node.val);
        BuildListFromTree(node.right, list, k);
      }
    }

    private int KthSmallestUsingInOrder(TreeNode root, int k)
    {
      var list = new List<int>();
      BuildListFromTree(root, list, k);
      return list[k - 1];
    }

    [Theory]
    [InlineData("3,1,4,null,2", 1, 1)]
    public void CanFindKthSmallest(string tree, int k, int expected)
    {
      Assert.Equal(expected, KthSmallest(tree.AsTreeNode(), k));
    }
  }
}
