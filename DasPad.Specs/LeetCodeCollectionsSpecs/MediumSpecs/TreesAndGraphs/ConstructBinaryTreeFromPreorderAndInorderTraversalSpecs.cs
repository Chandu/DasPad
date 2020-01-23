using DasPad.Specs.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.TreesAndGraphs
{
  public class ConstructBinaryTreeFromPreorderAndInorderTraversalSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-medium/108/trees-and-graphs/788/
     * Given preorder and inorder traversal of a tree, construct the binary tree.

      Note:
      You may assume that duplicates do not exist in the tree.

      For example, given

      preorder = [3,9,20,15,7]
      inorder = [9,3,15,20,7]
      Return the following binary tree:

          3
         / \
        9  20
          /  \
         15   7
     */
    //TIP: Binary Tree from InOrder and Pre/Post Order
    /*
     * Let us consider the below traversals:

      Inorder sequence: D B E A F C
      Preorder sequence: A B D E C F

      In a Preorder sequence, leftmost element is the root of the tree. So we know ‘A’ is root for given sequences.
      By searching ‘A’ in Inorder sequence, we can find out all elements on left side of ‘A’ are in left subtree
      and elements on right are in right subtree. So we know below structure now.
     */

    //Revisit:

    //Tip:
    /*
     *The basic idea is here:
      Say we have 2 arrays, PRE and IN.
      Preorder traversing implies that PRE[0] is the root node.
      Then we can find this PRE[0] in IN, say it's IN[5].
      Now we know that IN[5] is root, so we know that IN[0] - IN[4] is on the left side, IN[6] to the end is on the right side.
      Recursively doing this on subarrays, we can build a tree out of it :)
     */

    public TreeNode BuildTree(int[] preOrder, int[] inOrder)
    {
      var inOrderHash = new Dictionary<int, int>();
      for (var i = 0; i < inOrder.Length; i++)
      {
        inOrderHash[inOrder[i]] = i;
      }
      return helper(0, 0, inOrder.Length - 1, preOrder, inOrder, inOrderHash);
    }

    public TreeNode helper(int preStart, int inStart, int inEnd, int[] preOrder, int[] inOrder, Dictionary<int, int> inOrderHash)
    {
      if (preStart > preOrder.Length - 1 || inStart > inEnd)
      {
        return null;
      }
      TreeNode root = new TreeNode(preOrder[preStart]);
      int inIndex = inOrderHash[root.val];
      root.left = helper(preStart + 1, inStart, inIndex - 1, preOrder, inOrder, inOrderHash);
      root.right = helper(preStart + inIndex - inStart + 1, inIndex + 1, inEnd, preOrder, inOrder, inOrderHash);
      return root;
    }

    [Theory]
    [InlineData("3,9,20,15,7", "9,3,15,20,7", "3,9,20,null,null,15,7")]
    public void CanBuildTree(string preorder, string inorder, string expected)
    {
      var preorderNodes = preorder.Split(',').Select(a => int.Parse(a.Trim())).ToArray();
      var inorderNodes = inorder.Split(',').Select(a => int.Parse(a.Trim())).ToArray();
      var expectedNode = expected.AsTreeNode();
      Assert.Equal(expectedNode.AsString(), BuildTree(preorderNodes, inorderNodes).AsString());
    }
  }
}
