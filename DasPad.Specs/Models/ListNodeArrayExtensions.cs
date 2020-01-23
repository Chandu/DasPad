using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DasPad.Specs.Models
{
  public static class ListNodeArrayExtensions
  {
    public static ListNode ToListNode(this IEnumerable<int> input, bool createCycles = false)
    {
      var nodesMap = new Dictionary<int, ListNode>();
      ListNode listNode = null;
      ListNode curNode = null;
      foreach (var a in input)
      {
        var node = (createCycles && nodesMap.ContainsKey(a)) ? nodesMap[a] : (nodesMap[a] = new ListNode(a));
        if (listNode == null)
        {
          listNode = node;
          curNode = node;
        }
        else
        {
          curNode.next = node;
          curNode = node;
        }
      }
      return listNode;
    }

    public static ListNode ToListNode(this string input, bool createCycles = false)
    {
      return input.Split(',').Select(a => Int32.Parse(a)).ToListNode(createCycles);
    }

    public static ListNode ArrowedToListNode(this string input)
    {
      return input.Split(new string[] { "->" }, StringSplitOptions.None).Select(a => Int32.Parse(a)).ToListNode();
    }

    public static string AsString(this ListNode node)
    {
      var sb = new StringBuilder();
      while (node != null)
      {
        sb.Append(node.val + ", ");
        node = node.next;
      }
      return sb.ToString().Trim().TrimEnd(new[] { ',' });
    }
  }
}
