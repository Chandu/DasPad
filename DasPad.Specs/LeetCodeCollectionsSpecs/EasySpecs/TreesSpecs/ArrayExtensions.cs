using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.TreesSpecs
{
  public static class ArrayExtensions
  {
    //TODO: (CV) Important Check this for BST SerDe
    public static TreeNode ToTreeNode(this string[] values)
    {
      if (values == null || values.Length < 1)
      {
        return null;
      }

      TreeNode[] nodes = new TreeNode[values.Length];
      int i = -1;
      int j = 0;

      while (++i < values.Length)
      {
        nodes[i] = (values[i] == "null" || values[i] == null) ? null : new TreeNode(int.Parse(values[i].Trim()));
      }
      i = -1;
      while (++i < values.Length)
      {
        if (nodes[i] != null)
        {
          int leftIdx = (2 * j) + 1;
          int rightIdx = (2 * j) + 2;
          if (leftIdx < values.Length)
          {
            nodes[i].left = nodes[leftIdx];
          }
          if (rightIdx < values.Length)
          {
            nodes[i].right = nodes[rightIdx];
          }
          j++;
        }
      }

      return nodes[0];
    }

    public static TreeNode ToTreeNode(this string input)
    {
      if (input == null || input.Trim().Length < 1)
      {
        return null;
      }

      return input.Split(',').Select(a =>
      {
        if (a == null || a.Trim().Length < 1 || !Int32.TryParse(a.Trim(), out int _))
        {
          return null;
        }
        else
        {
          return a.Trim();
        }
      }).ToArray().ToTreeNode();
    }

    public static string AsString(this TreeNode rootNode)
    {
      if (rootNode == null)
      {
        return string.Empty;
      }
      var sb = new StringBuilder();
      var queue = new Queue<TreeNode>();
      queue.Enqueue(rootNode);
      while (queue.Count > 0)
      {
        var node = queue.Dequeue();
        if (node == null)
        {
          sb.Append("null").Append(", ");
        }
        else
        {
          sb.Append(node.val).Append(", ");
          if (true || node.left != null)
          {
            queue.Enqueue(node.left);
          }
          if (true || node.right != null)
          {
            queue.Enqueue(node.right);
          }
        }
      }
      return Regex.Replace(sb.ToString().Trim().TrimEnd(new[] { ',' }), "(, null)*$", "");
    }
  }
}
