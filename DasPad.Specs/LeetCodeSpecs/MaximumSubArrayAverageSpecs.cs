using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class MaximumSubArrayAverageSpecs
  {
    public double FindMaxAverage(int[] arr, int K)
    {
      double[] result = new double[arr.Length - K + 1];
      double windowSum = 0;
      int windowStart = 0;
      for (int windowEnd = 0; windowEnd < arr.Length; windowEnd++)
      {
        windowSum += arr[windowEnd]; // add the next element
                                     // slide the window, we don't need to slide if we've not hit the required window size of 'k'
        if (windowEnd >= K - 1)
        {
          result[windowStart] = windowSum / K; // calculate the average
          windowSum -= arr[windowStart]; // subtract the element going out
          windowStart++; // slide the window ahead
        }
      }

      return result.Max();
    }

    [Fact]
    public void CanFindMaxAverage()
    {
      var input = new[] { 1, 12, -5, -6, 50, 3 };
      var k = 4;
      Assert.Equal(12.75, FindMaxAverage(input, k));
    }
  }
}
