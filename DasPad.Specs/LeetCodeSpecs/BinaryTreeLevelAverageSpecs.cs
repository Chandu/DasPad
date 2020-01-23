using DasPad.Specs.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class BinaryTreeLevelAverageSpecs
  {
    public IList<double> AverageOfLevels(TreeNode root)
    {
      if (root == null)
      {
        return Enumerable.Empty<double>().ToList();
      }

      var toReturn = new List<double>();
      var queue = new Queue<TreeNode>();
      queue.Enqueue(root);
      queue.Enqueue(null);
      while (queue.Count > 0)
      {
        var values = new List<double>();
        var needsMarker = false;
        while (queue.Peek() != null)
        {
          var node = queue.Dequeue();
          values.Add(node.val);
          if (node.left != null)
          {
            queue.Enqueue(node.left);
            needsMarker = true;
          }
          if (node.right != null)
          {
            queue.Enqueue(node.right);
            needsMarker = true;
          }
        }
        queue.Dequeue();
        if (values.Any())
        {
          toReturn.Add(values.Sum() / values.Count());
        }
        if (needsMarker)
        {
          queue.Enqueue(null);
        }
      }
      return toReturn;
    }

    public static string ArrayToString<T>(T[] arr)
    {
      var toReturn = "";
      for (var i = 0; i < arr.Length; i++)
      {
        toReturn += arr[i].ToString() + " ";
      }
      return toReturn;
    }

    [Fact]
    public void CanAverageOfLevels()
    {
      var input = new TreeNode(3)
      {
        left = new TreeNode(9),
        right = new TreeNode(20)
        {
          left = new TreeNode(15),
          right = new TreeNode(7),
        }
      };
      Assert.Equal(ArrayToString(new[] { 3, 14.5, 11 }), ArrayToString(AverageOfLevels(input).ToArray()));
    }
  }
}
