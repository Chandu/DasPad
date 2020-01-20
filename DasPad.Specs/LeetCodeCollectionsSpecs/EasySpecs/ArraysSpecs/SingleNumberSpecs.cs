using System.Collections.Generic;
using System.Linq;
using Xunit;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.EasySpecs.ArraysSpecs
{
  public class SingleNumberSpecs
  {
    //TODO: (CV) https://leetcode.com/explore/interview/card/top-interview-questions-easy/92/array/549/
    /*
     * Given a non-empty array of integers, every element appears twice except for one. Find that single one.

        Note:

        Your algorithm should have a linear runtime complexity. Could you implement it without using extra memory?

        Example 1:

        Input: [2,2,1]
        Output: 1
        Example 2:

        Input: [4,1,2,1,2]
        Output: 4
     */

    //TODO: TIP - > XOR of a number twice is 0;
    /*
     *  a) XOR of a number with itself is 0.
        b) XOR of a number with 0 is number itself.

        Let us consider the above example.  
        Let ^ be xor operator as in C and C++.

        res = 7 ^ 3 ^ 5 ^ 4 ^ 5 ^ 3 ^ 4

        Since XOR is associative and commutative, above 
        expression can be written as:
        res = 7 ^ (3 ^ 3) ^ (4 ^ 4) ^ (5 ^ 5)  
            = 7 ^ 0 ^ 0 ^ 0
            = 7 ^ 0
            = 7 
     */
    public int SingleNumber(int[] nums)
    {
      var first = nums[0];
      for (var i = 1; i < nums.Length; i++)
      {
        first ^= nums[i];
      }

      return first;
    }

    public int SingleNumberWithHash(int[] nums)
    {
      var hashSet = new HashSet<int>();
      foreach (var c in nums)
      {
        if (hashSet.Contains(c))
        {
          hashSet.Remove(c);
        }
        else
        {
          hashSet.Add(c);
        }
      }
      return hashSet.First();
    }

    [Fact]
    public void CanSingleNumber()
    {
      Assert.Equal(1, SingleNumber(AsArray(2, 2, 1)));
      Assert.Equal(4, SingleNumber(AsArray(4, 1, 2, 1, 2)));
    }
  }
}
