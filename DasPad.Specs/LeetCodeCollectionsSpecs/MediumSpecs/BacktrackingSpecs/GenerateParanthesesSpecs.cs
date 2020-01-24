using System.Collections.Generic;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.BacktrackingSpecs
{
  public class GenerateParanthesesSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-medium/109/backtracking/794/
     * Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

        For example, given n = 3, a solution set is:

        [
          "((()))",
          "(()())",
          "(())()",
          "()(())",
          "()()()"
        ]
     */

    //Revisit
    public IList<string> GenerateParenthesis(int n)
    {
      List<string> ans = new List<string>();
      Backtrack(ans, "", 0, 0, n);
      return ans;
    }

    private void Backtrack(List<string> ans, string cur, int open, int close, int max)
    {
      if (cur.Length == max * 2)
      {
        ans.Add(cur);
        return;
      }

      if (open < max)
        Backtrack(ans, cur + "(", open + 1, close, max);
      if (close < open)
        Backtrack(ans, cur + ")", open, close + 1, max);
    }
  }
}
