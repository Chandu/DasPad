using System.Collections.Generic;
using System.Linq;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.TreesSpecs
{
  internal class BinaryTreeLevelOrderTraversalSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-easy/94/trees/628/
     * Given a binary tree, return the level order traversal of its nodes' values. (ie, from left to right, level by level).

        For example:
        Given binary tree [3,9,20,null,null,15,7],
            3
           / \
          9  20
            /  \
           15   7
        return its level order traversal as:
        [
          [3],
          [9,20],
          [15,7]
        ]
     */

    //TIP This is the logic to identify the level of node in QUEUE while BFS of TREE.
    //Level is equal to the number of items in the queue.
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
      if (root == null)
      {
        return Enumerable.Empty<IList<int>>().ToList();
      }
      var queue = new Queue<TreeNode>();
      queue.Enqueue(root);
      var toReturn = new List<IList<int>>();
      while (queue.Count > 0)
      {
        var level = queue.Count();
        var curList = new List<int>();
        for (var i = 0; i < level; i++)
        {
          var curPeek = queue.Peek();
          if (curPeek.left != null)
          {
            queue.Enqueue(curPeek.left);
          }
          if (curPeek.right != null)
          {
            queue.Enqueue(curPeek.right);
          }
          curList.Add(queue.Dequeue().val);
        }
        toReturn.Add(curList);
      }

      return toReturn;
    }
  }
}
