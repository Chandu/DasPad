using DasPad.Specs.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.TreesAndGraphs
{
  public class BinaryTreeZigzagLevelOrderTraversalSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-medium/108/trees-and-graphs/787/
     * Given a binary tree, return the zigzag level order traversal of its nodes' values. (ie, from left to right, then right to left for the next level and alternate between).

      For example:
      Given binary tree [3,9,20,null,null,15,7],
          3
         / \
        9  20
          /  \
         15   7
      return its zigzag level order traversal as:
      [
        [3],
        [20,9],
        [15,7]
      ]
     */

    //TIP: Nice Technique.. I sintuitive if you traverse teh zig zag on paper/board.
    public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
    {
      var firstStack = new Stack<TreeNode>();
      var secondStack = new Stack<TreeNode>();
      var toReturn = new List<IList<int>>();
      firstStack.Push(root);
      var index = 0;
      while (firstStack.Count > 0 || secondStack.Count > 0)
      {
        var list = new List<int>();
        var sourceStack = (firstStack.Count == 0) ? secondStack : firstStack;
        var targetStack = (firstStack.Count != 0) ? secondStack : firstStack;
        var rtlDirection = (firstStack.Count == 0);
        var sourceStackCount = sourceStack.Count;

        for (var i = 0; i < sourceStackCount; i++)
        {
          var node = sourceStack.Pop();
          if (node != null)
          {
            list.Add(node.val);
            if (rtlDirection)
            {
              if (node.right != null)
              {
                targetStack.Push(node.right);
              }
              if (node.left != null)
              {
                targetStack.Push(node.left);
              }
            }
            else
            {
              if (node.left != null)
              {
                targetStack.Push(node.left);
              }
              if (node.right != null)
              {
                targetStack.Push(node.right);
              }
            }
          }
        }
        if (list.Any())
        {
          toReturn.Add(list);
        }

        index++;
      }
      return toReturn;
    }

    [Fact]
    public void CanZigzagLevelOrder()
    {
      Assert.Equal(AsArray(AsArray(3), AsArray(20, 9), AsArray(15, 7)), ZigzagLevelOrder("3,9,20,null,null,15,7".AsTreeNode()));

      Assert.Equal(AsArray(AsArray(1), AsArray(3, 2), AsArray(4, 5)), ZigzagLevelOrder("1,2,3,4,null,null,5".AsTreeNode()));
    }
  }
}
