using System;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.OthersSpecs
{
  public class EvaluateReversePolishNotationSpecs
  {
    /*
     * Evaluate the value of an arithmetic expression in Reverse Polish Notation.

        Valid operators are +, -, *, /. Each operand may be an integer or another expression.

        Note:

        Division between two integers should truncate toward zero.
        The given RPN expression is always valid. That means the expression would always evaluate to a result and there won't be any divide by zero operation.
        Example 1:

        Input: ["2", "1", "+", "3", "*"]
        Output: 9
        Explanation: ((2 + 1) * 3) = 9
        Example 2:

        Input: ["4", "13", "5", "/", "+"]
        Output: 6
        Explanation: (4 + (13 / 5)) = 6
        Example 3:

        Input: ["10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+"]
        Output: 22
        Explanation:
          ((10 * (6 / ((9 + 3) * -11))) + 17) + 5
        = ((10 * (6 / (12 * -11))) + 17) + 5
        = ((10 * (6 / -132)) + 17) + 5
        = ((10 * 0) + 17) + 5
        = (0 + 17) + 5
        = 17 + 5
        = 22
     */

    public int EvalRPN(string[] tokens)
    {
      var stack = new Stack<string>();
      var fnsMap = new Dictionary<string, Func<int, int, int>>()
      {
        ["+"] = (a, b) => a + b,
        ["-"] = (a, b) => a - b,
        ["*"] = (a, b) => a * b,
        ["/"] = (a, b) => a / b,
      };
      foreach (var token in tokens)
      {
        switch (token)
        {
          case "+":
          case "-":
          case "*":
          case "/":
            var right = int.Parse(stack.Pop());
            var left = int.Parse(stack.Pop());
            stack.Push(fnsMap[token](left, right).ToString());
            break;

          default:
            stack.Push(token);
            break;
        }
      }
      return int.Parse(stack.Pop());
    }

    [Theory]
    [InlineData(9, "2", "1", "+", "3", "*")]
    [InlineData(22, "10", "6", "9", "3", "+", "-11", "*", "/", "*", "17", "+", "5", "+")]
    public void CanEvalRPN(int expected, params string[] tokens)
    {
      Assert.Equal(expected, EvalRPN(tokens));
    }
  }
}
