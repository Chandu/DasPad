using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static DasPad.Specs.Utils;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.ArraysAndStringsSpecs
{
  public class ThreeSumSpecs
    {
        /*
         * https://leetcode.com/explore/interview/card/top-interview-questions-medium/103/array-and-strings/776/
         * Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? Find all unique triplets in the array which gives the sum of zero.

            Note:

            The solution set must not contain duplicate triplets.

            Example:

            Given array nums = [-1, 0, 1, 2, -1, -4],

            A solution set is:
            [
              [-1, 0, 1],
              [-1, -1, 2]
            ]
        */

        public IList<IList<int>> ThreeSum(int[] nums)
        {
            return ThreeSumUsingTwoPointersAndSortedArray(nums);
        }

        public IList<IList<int>> ThreeSumUsingTwoPointersAndSortedArray(int[] nums)
        {
            Array.Sort(nums);
            var toReturn = new List<IList<int>>();
            for (var i = 0; i < nums.Length; i++)
            {
                //TIP: The Condition Below is to skip the element if it was already processed and also to skip elements that could never sum up to 0 i.e. anything > 0.
                if (i == 0 || (nums[i - 1] != nums[i] && nums[i] <= 0))
                {
                    //TIP: Using Two pointers approach instead of a complements HashMap is better in terms of Space.
                    var low = i + 1;
                    var high = nums.Length - 1;
                    //This is our target sum from rest of the array.
                    var sum = 0 - nums[i];
                    //TIP: Two pointer approach to find the elements of sorted aray for a sum x, wihtout using Complements Hash.
                    while (low < high)
                    {
                        if (nums[low] + nums[high] == sum)
                        {
                            toReturn.Add(new[] { nums[i], nums[low], nums[high] });
                            while (low < high && nums[low] == nums[low + 1])
                            {
                                low++;
                            }

                            while (low < high && nums[high] == nums[high - 1])
                            {
                                high--;
                            }

                            low++;
                            high--;
                        }
                        else if (nums[low] + nums[high] < sum)
                        {
                            low++;
                        }
                        else
                        {
                            high--;
                        }
                    }
                }
            }
            return toReturn;
        }

        public IList<IList<int>> ThreeSumBruteForce(int[] nums)
        {
            Array.Sort(nums);
            var hashSet = new HashSet<(int, int, int)>();
            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    for (var k = j + 1; k < nums.Length; k++)
                    {
                        if (nums[i] + nums[j] + nums[k] == 0)
                        {
                            hashSet.Add((nums[i], nums[j], nums[k]));
                        }
                    }
                }
            }
            var toReturn = new List<IList<int>>();
            hashSet.ToList().ForEach(a => toReturn.Add(new[] { a.Item1, a.Item2, a.Item3 }));
            return toReturn;
        }

        [Fact]
        public void CanThreeSum()
        {
            Assert.Equal(AsArray(AsArray(-1, -1, 2), AsArray(-1, 0, 1)), ThreeSum(AsArray(-1, 0, 1, 2, -1, -4)));
            Assert.Equal(new[] { AsArray(0, 0, 0) }, ThreeSum(AsArray(0, 0, 0)));
        }
    }
}