//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Xunit;

//namespace DasPad.Specs.YangshunSpecs.DpSpecs
//{
//  public class ExpressionsAndOperatorsSpecs
//  {
//    //TODO: (CV)  https://leetcode.com/problems/expression-add-operators/
//    /*
//     * Given a string that contains only digits 0-9 and a target value, return all possibilities to add binary operators (not unary) +, -, or * between the digits so they evaluate to the target value.

//      Example 1:

//      Input: num = "123", target = 6
//      Output: ["1+2+3", "1*2*3"]
//      Example 2:

//      Input: num = "232", target = 8
//      Output: ["2*3+2", "2+3*2"]
//      Example 3:

//      Input: num = "105", target = 5
//      Output: ["1*0+5","10-5"]
//      Example 4:

//      Input: num = "00", target = 0
//      Output: ["0+0", "0-0", "0*0"]
//      Example 5:

//      Input: num = "3456237490", target = 9191
//      Output: []
//     */

//    public IList<string> AddOperators(string num, int target)
//    {
//      if (num == null || num.Trim().Length == 0)
//      {
//        return Enumerable.Empty<string>().ToList();
//      }
//      var expressionList = new List<string>();
//      GenerateAllExpressions(num.Substring(1), num[0].ToString(), expressionList);
//      return expressionList.Where(a => DoesEvaluateTo(a, target)).ToList;
//    }

//    private bool DoesEvaluateTo(string expression, int target)
//    {
//      return false;
//    }

//    private void GenerateAllExpressions(string num, string expression, List<string> expressionList)
//    {
//      if (num == null || num.Trim().Length == 0)
//      {
//        expressionList.Add(expression);
//      }
//      else if (num.Length == 1)
//      {
//        expressionList.Add($"{expression}+{num}");
//        expressionList.Add($"{expression}*{num}");
//        expressionList.Add($"{expression}-{num}");
//      }
//      else
//      {
//        var curNum = Int32.Parse(num[0].ToString());
//        GenerateAllExpressions(num.Substring(1), $"{expression}+{curNum}", expressionList);
//        GenerateAllExpressions(num.Substring(1), $"{expression}-{curNum}", expressionList);
//        GenerateAllExpressions(num.Substring(1), $"{expression}*{curNum}", expressionList);
//      }
//    }

//    [Theory(Timeout = 1)]
//    [InlineData("123", 6, "1+2+3, 1*2*3")]
//    [InlineData("232", 8, "2*3+2, 2+3*2")]
//    public void CanAddOperators(string input, int target, string expressions)
//    {
//      var expected = expressions.Split(',').Select(a => a.Trim()).ToList();
//      Assert.Equal(expected, AddOperators(input, target));
//    }
//  }
//}
