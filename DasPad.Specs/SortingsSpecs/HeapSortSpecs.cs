using DasPad.Specs.Extensions;
using System.Linq;
using Xunit;

namespace DasPad.Specs.SortingsSpecs
{
  public class HeapSortSpecs
  {
    private static void Swap(int[] inputArray, int left, int right)
    {
      var temp = inputArray[left];
      inputArray[left] = inputArray[right];
      inputArray[right] = temp;
    }

    internal static void Heapify(int[] nums, int startIndex, int end)
    {
      if (startIndex < end)
      {
        var leftIndex = 2 * startIndex + 1;
        var rightIndex = 2 * startIndex + 2;
        var largestIndex = startIndex;
        if (leftIndex < end && nums[leftIndex] > nums[largestIndex])
        {
          largestIndex = leftIndex;
        }
        if (rightIndex < end && nums[rightIndex] > nums[largestIndex])
        {
          largestIndex = rightIndex;
        }
        if (largestIndex != startIndex)
        {
          Swap(nums, startIndex, largestIndex);
          Heapify(nums, largestIndex, end);
        }
      }
    }

    private static int[] HeapSort(int[] nums)
    {
      var workedArray = nums.Clone() as int[];

      for (int i = (workedArray.Length / 2) - 1; i >= 0; i--)
      {
        Heapify(workedArray, i, workedArray.Length);
      }

      for (int i = workedArray.Length - 1; i >= 0; i--)
      {
        // Move current root to end
        Swap(workedArray, 0, i);

        // call max heapify on the reduced heap
        Heapify(workedArray, 0, i);
      }
      return workedArray;
    }

    [Theory]
    [InlineData("4, 10, 3, 5, 1")]
    public void CanHeapSort(string input)
    {
      Assert.Equal(input.AsIntsFromCsv().OrderBy(a => a).ToArray(), HeapSort(input.AsIntsFromCsv()));
    }
  }
}
