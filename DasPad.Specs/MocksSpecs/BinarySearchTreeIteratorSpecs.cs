using DasPad.Specs.Models;
using System.Collections.Generic;
using System.Threading;

namespace DasPad.Specs.MocksSpecs
{
  public class BinarySearchTreeIteratorSpecs
  {
    /*
     * https://leetcode.com/problems/binary-search-tree-iterator/
     * 173. Binary Search Tree Iterator
        Medium

        1952

        260

        Add to List

        Share
        Implement an iterator over a binary search tree (BST). Your iterator will be initialized with the root node of a BST.

        Calling next() will return the next smallest number in the BST.

        Example:

        BSTIterator iterator = new BSTIterator(root);
        iterator.next();    // return 3
        iterator.next();    // return 7
        iterator.hasNext(); // return true
        iterator.next();    // return 9
        iterator.hasNext(); // return true
        iterator.next();    // return 15
        iterator.hasNext(); // return true
        iterator.next();    // return 20
        iterator.hasNext(); // return false

        Note:

        next() and hasNext() should run in average O(1) time and uses O(h) memory, where h is the height of the tree.
        You may assume that next() call will always be valid, that is, there will be at least a next smallest number in the BST when next() is called.
     */
    /**
* Definition for a binary tree node.
* public class TreeNode {
*     public int val;
*     public TreeNode left;
*     public TreeNode right;
*     public TreeNode(int x) { val = x; }
* }
*/

    public class BSTIterator
    {
      private Stack<TreeNode> stack = new Stack<TreeNode>();

      public BSTIterator(TreeNode root)
      {
        var a = new Semaphore(1, 1);
        if (root != null)
        {
          this.ProcessLeftNodes(root);
        }
      }

      private void ProcessLeftNodes(TreeNode node)
      {
        while (node != null)
        {
          this.stack.Push(node);
          node = node.left;
        }
      }

      /** @return the next smallest number */

      public int Next()
      {
        if (this.stack.Count > 0)
        {
          var node = this.stack.Pop();
          this.ProcessLeftNodes(node.right);
          return node.val;
        }
        else
        {
          return -1;
        }
      }

      /** @return whether we have a next smallest number */

      public bool HasNext()
      {
        return this.stack.Count != 0;
      }
    }

    /**
     * Your BSTIterator object will be instantiated and called as such:
     * BSTIterator obj = new BSTIterator(root);
     * int param_1 = obj.Next();
     * bool param_2 = obj.HasNext();
     */
  }
}
