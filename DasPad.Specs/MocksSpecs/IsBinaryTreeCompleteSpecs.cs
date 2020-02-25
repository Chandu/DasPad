using DasPad.Specs.Models;
using System.Collections.Generic;
using System.Linq;

namespace DasPad.Specs.MocksSpecs
{
  public class IsBinaryTreeCompleteSpecs
  {
    /*
     * https://leetcode.com/problems/check-completeness-of-a-binary-tree/
     * 958. Check Completeness of a Binary Tree
      Medium

      519

      10

      Add to List

      Share
      Given a binary tree, determine if it is a complete binary tree.

      Definition of a complete binary tree from Wikipedia:
      In a complete binary tree every level, except possibly the last, is completely filled, and all nodes in the last level are as far left as possible. It can have between 1 and 2h nodes inclusive at the last level h.

      Example 1:

      Input: [1,2,3,4,5,6]
      Output: true
      Explanation: Every level before the last is full (ie. levels with node-values {1} and {2, 3}), and all nodes in the last level ({4, 5, 6}) are as far left as possible.
      Example 2:

      Input: [1,2,3,4,5,null,7]
      Output: false
      Explanation: The node with value 7 isn't as far left as possible.

      Note:

      The tree will have between 1 and 100 nodes.
     */

    //Trick
    public bool IsCompleteTree(TreeNode root)
    {
      var queue = new Queue<TreeNode>();
      queue.Enqueue(root);
      while (queue.Count > 0)
      {
        var size = queue.Count();
        for (var i = 0; i < size; i++)
        {
          var node = queue.Dequeue();
          if (queue.Count > 0 && node == null && queue.Peek() != null)
          {
            return false;
          }
          if (node != null)
          {
            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
          }
        }
      }
      return true;
    }
  }
}
