using DasPad.Specs.Models;
using System.Collections.Generic;

namespace DasPad.Specs.LeetCodeSpecs
{
    public class TargetNumberInBstSpecs
    {
        //TODO: (CV) https://leetcode.com/problems/two-sum-iv-input-is-a-bst/solution/
        //TODO: (CV) Interesting
        /*
         * SOlutions: Hashset, BST, InOrder of BST yields sorted array then it boiis down to finding two numbers in array using two pointers.
         */

        /*
         * Given a Binary Search Tree and a target number, return true if there exist two elements in the BST such that their sum is equal to the given target.

          Example 1:

          Input:
              5
             / \
            3   6
           / \   \
          2   4   7

          Target = 9

          Output: True

         */

        public bool FindTarget(TreeNode root, int k)
        {
            HashSet<int> set = new HashSet<int>();
            return Find(root, k, set);
        }

        public bool Find(TreeNode root, int k, HashSet<int> set)
        {
            if (root == null)
            {
                return false;
            }

            if (set.Contains(k - root.val))
            {
                return true;
            }
            set.Add(root.val);
            return Find(root.left, k, set) || Find(root.right, k, set);
        }
    }
}