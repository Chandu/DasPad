using System;
using System.Collections.Generic;

namespace DasPad.Uber
{
  public static class IndicesOfSum
  {
    public static int[] TwoSum(int[] inputArray, int targetSum)
    {
      if (inputArray.Length < 2)
      {
        throw new ArgumentException("Size of array should be greater than 1.");
      }
      var complementsArray = new Dictionary<int, int>();
      for (var i = 0; i < inputArray.Length; i++)
      {
        var cur = inputArray[i];
        var complement = targetSum - cur;
        if (complementsArray.ContainsKey(complement))
        {
          return new[]
          {
            complementsArray[complement],
            i
          };
        }
        else if (!complementsArray.ContainsKey(cur))
        {
          complementsArray.Add(cur, i);
        }
      }
      return Array.Empty<int>();
    }
  }
}
