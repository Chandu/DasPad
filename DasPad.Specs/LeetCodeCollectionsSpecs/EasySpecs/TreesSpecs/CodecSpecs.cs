using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.TreesSpecs
{
  public class CodecSpecs
  {
    public class Codec
    {
      // Encodes a tree to a single string.
      public String serialize(TreeNode root)
      {
        if (root == null)
        {
          return null;
        }
        return convertToString(root);
      }

      // Decodes your encoded data to tree.
      public TreeNode deserialize(String data)
      {
        if (data == null)
        {
          return null;
        }
        return convertToTree(data);
      }

      private String convertToString(TreeNode root)
      {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        List<string> values = new List<string>();
        StringBuilder valuesStr = new StringBuilder();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
          TreeNode currNode = queue.Dequeue();
          values.Add(currNode == null ? "null" : currNode.val.ToString());
          if (currNode != null)
          {
            queue.Enqueue(currNode.left);
            queue.Enqueue(currNode.right);
          }
        }
        int i = values.Count();
        while (--i >= 0 && values[i] == "null") ;
        for (int j = 0; j <= i; j++)
        {
          valuesStr.Append(values[j] + ",");
        }

        return valuesStr.ToString().TrimEnd(new[] { ',' });
      }

      private TreeNode convertToTree(String valuesStr)
      {
        String[] values = valuesStr.Split(',');
        TreeNode[] nodes = new TreeNode[values.Length];
        int i = -1;
        int j = 0;

        while (++i < values.Length)
        {
          nodes[i] = values[i] == "null" ? null : new TreeNode(int.Parse(values[i]));
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
    }

    [Theory]
    [InlineData("1,2,3,4,5,6")]
    [InlineData("1,2,3,null,null,5,6")]
    [InlineData("5,2,3,null,null,2,4,3,1")]
    public void CanSerializeAndDeserialize(string ser)
    {
      var codec = new Codec();
      Assert.Equal(ser, codec.serialize(codec.deserialize(ser)));
    }
  }
}
