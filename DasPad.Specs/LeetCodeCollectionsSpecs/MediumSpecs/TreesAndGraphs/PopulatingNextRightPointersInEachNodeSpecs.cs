using System.Collections.Generic;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.TreesAndGraphs
{
  public class PopulatingNextRightPointersInEachNodeSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-medium/108/trees-and-graphs/789/
     * You are given a perfect binary tree where all leaves are on the same level, and every parent has two children. The binary tree has the following definition:

      struct Node {
        int val;
        Node *left;
        Node *right;
        Node *next;
      }
      Populate each next pointer to point to its next right node. If there is no next right node, the next pointer should be set to NULL.

      Initially, all next pointers are set to NULL.

      Follow up:

      You may only use constant extra space.
      Recursive approach is fine, you may assume implicit stack space does not count as extra space for this problem.

      Example 1:

      Input: root = [1,2,3,4,5,6,7]
      Output: [1,#,2,3,#,4,5,6,7,#]
      Explanation: Given the above perfect binary tree (Figure A), your function should populate each next pointer to point to its next right node, just like in Figure B. The serialized output is in level order as connected by the next pointers, with '#' signifying the end of each level.

      Constraints:

      The number of nodes in the given tree is less than 4096.
      -1000 <= node.val <= 1000
     */

    public class Node
    {
      public int val;
      public Node left;
      public Node right;
      public Node next;

      public Node()
      {
      }

      public Node(int _val)
      {
        val = _val;
      }

      public Node(int _val, Node _left, Node _right, Node _next)
      {
        val = _val;
        left = _left;
        right = _right;
        next = _next;
      }
    }

    public Node Connect(Node root)
    {
      if (root == null)
      {
        return root;
      }
      ConnectNodeChilds(root);
      return root;
    }

    public Node ConnectIterative(Node root)
    {
      var queue = new Queue<Node>();
      queue.Enqueue(root);
      while (queue.Count > 0)
      {
        var queueCount = queue.Count;
        for (var i = 0; i < queueCount; i++)
        {
          var node = queue.Dequeue();
          if (i != queueCount - 1)
          {
            node.next = queue.Peek();
          }
          if (node.left != null)
          {
            queue.Enqueue(node.left);
          }
          if (node.right != null)
          {
            queue.Enqueue(node.right);
          }
        }
      }
      return root;
    }

    //Revisit:
    //Note: Not my solution, but was from LeetCode Submission Detail page. Looks like it's based on the point that it is a Perfect Binary Tree. A simple and elegant solution with no additional space
    private void ConnectNodeChilds(Node node)
    {
      if (node == null || node.left == null || node.right == null)
        return;

      node.left.next = node.right;
      node.right.next = node.next != null ? node.next.left : null;
      ConnectNodeChilds(node.left);
      ConnectNodeChilds(node.right);
    }
  }
}
