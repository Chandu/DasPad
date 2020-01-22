using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.OthersSpecs
{
  public class ValidParanthesesSpecs
  {
    /*
     * Given a string containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

      An input string is valid if:

      Open brackets must be closed by the same type of brackets.
      Open brackets must be closed in the correct order.
      Note that an empty string is also considered valid.

      Example 1:

      Input: "()"
      Output: true
      Example 2:

      Input: "()[]{}"
      Output: true
      Example 3:

      Input: "(]"
      Output: false
      Example 4:

      Input: "([)]"
      Output: false
      Example 5:

      Input: "{[]}"
      Output: true
     */

    public bool IsValid(string s)
    {
      var stack = new Stack<char>();

      var i = 0;
      var charsMap = new Dictionary<char, char>()
      {
        { ')', '('},
        {  '}', '{'},
        { ']', '[' },
      };
      while (i < s.Length)
      {
        if (s[i] == ')' || s[i] == '}' || s[i] == ']')
        {
          if (stack.Count == 0 || stack.Pop() != charsMap[s[i]])
          {
            return false;
          }
        }
        else
        {
          stack.Push(s[i]);
        }

        i++;
      }
      return stack.Count == 0;
    }

    [Theory]
    [InlineData("()", true)]
    public void CanVerifyIsValid(string s, bool expected)
    {
      Assert.Equal(expected, IsValid(s));
    }
  }
}
