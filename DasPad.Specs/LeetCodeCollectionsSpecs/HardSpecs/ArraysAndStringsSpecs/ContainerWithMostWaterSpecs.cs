using System;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.HardSpecs.ArraysAndStringsSpecs
{
  public class ContainerWithMostWaterSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-hard/116/array-and-strings/830/
     * Given n non-negative integers a1, a2, ..., an , where each represents a point at coordinate (i, ai). n vertical lines are drawn such that the two endpoints of line i is at (i, ai) and (i, 0). Find two lines, which together with x-axis forms a container, such that the container contains the most water.

      Note: You may not slant the container and n is at least 2.

      The above vertical lines are represented by array [1,8,6,2,5,4,8,3,7]. In this case, the max area of water (blue section) the container can contain is 49.
     */
    /*
     * Here the basic approach is, a point can hold water only if there exists any point to it's left that is atleast a point higher than this one and same case on to it's right.
     * So what we do is we seep the heights array twice (once form left to right) and other time for right to left and identify the max height to it's left/right upto that point and store it correpondingly and then use these arrays to identify the area as we iterate throughthe array one time.
     *
     * Other approach is two pointer apporach.
     */

    //Revisit
    //Notes
    /*
     * Area between Containers i,i = (j-i) * Min(height[i], height[j])
     * Max Area = Max(for all i, j < n => (j-i) * Min(height[i], height[j]))
     */

    public int MaxArea(int[] height)
    {
      if (height.Length < 2)
      {
        return 0;
      }
      return MaxAreaTwoPinters(height);
    }

    public int MaxAreaTwoPinters(int[] height)
    {
      var left = 0;
      var right = height.Length - 1;
      var maxArea = 0;
      while (left < right)
      {
        var area = (right - left) * Math.Min(height[left], height[right]);
        if (area > maxArea)
        {
          maxArea = area;
        }
        //We perform this check to see which direction do we move the pointer.
        if (height[left] > height[right])
        {
          //We move the pointer to right because the area found so far is the maximum we can find with utilizing the full height of the point since any other point between left, right will now have lesser width and will contirbute area lesser than what we have for these points left and right.
          right--;
        }
        else
        {
          left++;
        }
      }
      return maxArea;
    }

    public int MaxAreaBruteForce(int[] height)
    {
      var maxArea = 0;
      for (var i = 0; i < height.Length; i++)
      {
        for (var j = i + 1; j < height.Length; j++)
        {
          var minHeight = Math.Min(height[i], height[j]);
          var area = minHeight * (j - i);
          maxArea = Math.Max(maxArea, area);
        }
      }
      return maxArea;
    }

    [Theory]
    [InlineData(49, 1, 8, 6, 2, 5, 4, 8, 3, 7)]
    public void CanMaxArea(int expected, params int[] height)
    {
      Assert.Equal(expected, MaxArea(height));
    }
  }
}
