using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.HardSpecs.ArraysAndStringsSpecs
{
  public class BasicCalculatorIISpecs
  {
    /*
     * Implement a basic calculator to evaluate a simple expression string.

      The expression string contains only non-negative integers, +, -, *, / operators and empty spaces . The integer division should truncate toward zero.

      Example 1:

      Input: "3+2*2"
      Output: 7
      Example 2:

      Input: " 3/2 "
      Output: 1
      Example 3:

      Input: " 3+5 / 2 "
      Output: 5
      Note:

      You may assume that the given expression is always valid.
      Do not use the eval built-in library function.
     */

    public int Calculate(string s)
    {
      int len;
      if (s == null || (len = s.Length) == 0) return 0;
      Stack<int> stack = new Stack<int>();
      int num = 0;
      char sign = '+';
      for (int i = 0; i < len; i++)
      {
        if (char.IsDigit(s[i]))
        {
          num = num * 10 + s[i] - '0';
        }
        if ((!char.IsDigit(s[i]) && ' ' != s[i]) || i == len - 1)
        {
          if (sign == '-')
          {
            stack.Push(-num);
          }
          if (sign == '+')
          {
            stack.Push(num);
          }
          if (sign == '*')
          {
            stack.Push(stack.Pop() * num);
          }
          if (sign == '/')
          {
            stack.Push(stack.Pop() / num);
          }
          sign = s[i];
          num = 0;
        }
      }

      int re = 0;
      foreach (int i in stack)
      {
        re += i;
      }
      return re;
    }

    [Theory]
    [InlineData("3+2*2", 7)]
    [InlineData("43+2*2", 47)]
    [InlineData(" 3+5 / 2 ", 5)]
    [InlineData("42", 42)]
    [InlineData("1337", 1337)]
    public void CanCalculate(string s, int expected)
    {
      Assert.Equal(expected, Calculate(s));
    }
  }
}
