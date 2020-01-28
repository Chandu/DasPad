using DasPad.Specs.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class MaximumWidthOfBinaryTreeSpecs
  {
    public int WidthOfBinaryTree(TreeNode root)
    {
      if (root == null)
      {
        return 0;
      }
      var queue = new Queue<TreeNode>();
      queue.Enqueue(root);
      var curMax = 0;
      while (queue.Count > 0)
      {
        var queueCount = queue.Count;
        var leftNonNull = -1;
        var rightNonNull = -1;
        for (var i = 0; i < queueCount; i++)
        {
          var node = queue.Dequeue();
          if (node != null)
          {
            if (leftNonNull == -1)
            {
              leftNonNull = i;
            }
            rightNonNull = i;
            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
          }
        }
        if (leftNonNull != -1)
        {
          Console.WriteLine("{0}, {1}, {2}", leftNonNull, rightNonNull, curMax);
          curMax = Math.Max(rightNonNull - leftNonNull + 1, curMax);
        }
      }
      return curMax;
    }

    [Theory]
    [InlineData("1,1,1,1,null,null,1,1,null,null,1", 8)]
    public void CanMaxWidth(string nodes, int expected)
    {
      //Assert.Equal(expected, WidthOfBinaryTree(nodes.AsTreeNode()));
    }
  }
}
