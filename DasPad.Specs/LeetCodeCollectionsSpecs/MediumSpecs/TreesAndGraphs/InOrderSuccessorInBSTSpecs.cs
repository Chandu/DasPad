using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.TreesAndGraphs
{
  public class InOrderSuccessorInBSTSpecs
  {
    /*
     * https://www.geeksforgeeks.org/inorder-successor-in-binary-search-tree/
     *
     * In Binary Tree, Inorder successor of a node is the next node in Inorder traversal of the Binary Tree. Inorder Successor is NULL for the last node in Inoorder traversal.
      In Binary Search Tree, Inorder Successor of an input node can also be defined as the node with the smallest key greater than the key of input node. So, it is sometimes important to find next node in sorted order.

      In the above diagram, inorder successor of 8 is 10, inorder successor of 10 is 12 and inorder successor of 14 is 20.
     * */
    //Note: As per BST InOrder traversal would yield the elements in the sequence order. Now the predeccsor of an element is the right most child in it's left subtree and the successor is the left most child in it's right subtree. This is infact used in BST insertion and delete operations to ensure the tree remains a BST
  }
}
