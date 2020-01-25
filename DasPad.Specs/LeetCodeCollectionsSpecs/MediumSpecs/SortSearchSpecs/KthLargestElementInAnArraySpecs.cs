using DasPad.Specs.Extensions;
using System;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.SortSearchSpecs
{
  public class KthLargestElementInAnArraySpecs
  {
    /*
     * Find the kth largest element in an unsorted array. Note that it is the kth largest element in the sorted order, not the kth distinct element.

      Example 1:

      Input: [3,2,1,5,6,4] and k = 2
      Output: 5
      Example 2:

      Input: [3,2,3,1,2,4,5,5,6] and k = 4
      Output: 4
      Note:
      You may assume k is always valid, 1 ≤ k ≤ array's length.
     */

    public int FindKthLargest(int[] nums, int k)
    {
      var sorted = Sort(nums, k);
      return sorted[nums.Length - k];
    }

    public int[] Sort(int[] nums, int limit)
    {
      //return HeapSort(nums, limit);
      //return MergeSort(nums);
      return QuickSort(nums);
    }

    private void Swap(int[] nums, int left, int right)
    {
      var temp = nums[left];
      nums[left] = nums[right];
      nums[right] = temp;
    }

    #region Quick Sort

    public int[] QuickSort(int[] nums)
    {
      var workedArray = nums.Clone() as int[];
      QuickSortHelper(workedArray, 0, workedArray.Length - 1);
      return workedArray;
    }

    private void QuickSortHelper(int[] nums, int low, int high)
    {
      if (low < high)
      {
        var p = PartitionInPlace(nums, low, high);
        QuickSortHelper(nums, low, p - 1);
        QuickSortHelper(nums, p + 1, high);
      }
    }

    public int PartitionInPlace(int[] input, int low, int high)
    {
      int pivot = input[high];

      // index of current smaller element compared to Pivot
      int i = (low - 1);
      for (int j = low; j < high; j++)
      {
        // If current element is smaller
        // than the pivot
        if (input[j] < pivot)
        {
          i++;

          // swap arr[i] and arr[j]
          Swap(input, i, j);
        }
      }

      // swap arr[i+1] and arr[high] (or pivot)
      Swap(input, i + 1, high);

      return i + 1;
    }

    #endregion Quick Sort

    #region HeapSort

    private void Heapify(int[] nums, int start, int end, Func<int, int, bool> compareFn)
    {
      var leftIndex = 2 * start + 1;
      var rightIndex = 2 * start + 2;
      var largestIndex = start;
      if (leftIndex < end && compareFn(nums[leftIndex], nums[largestIndex]))
      {
        largestIndex = leftIndex;
      }
      if (rightIndex < end && compareFn(nums[rightIndex], nums[largestIndex]))
      {
        largestIndex = rightIndex;
      }
      if (largestIndex != start)
      {
        Swap(nums, largestIndex, start);
        Heapify(nums, largestIndex, end, compareFn);
      }
    }

    public int[] HeapSort(int[] nums, int limit)
    {
      var workedArray = nums.Clone() as int[];
      var length = workedArray.Length;
      //Build the Max Heap since the array need not satisfy a heap structure in its raw form. We are starting from n/2 and moving down since these are all the non leaf nodes in a tree.
      for (var i = (length / 2) - 1; i >= 0; i--)
      {
        Heapify(workedArray, i, length, (a, b) => a > b);
      }
      for (var i = length - 1; i >= length - limit; i--)
      {
        Swap(workedArray, 0, i);
        Heapify(workedArray, 0, i, (a, b) => a > b);
      }
      return workedArray;
    }

    #endregion HeapSort

    #region Merge Sort

    public int[] MergeSort(int[] nums)
    {
      var workedArray = nums.Clone() as int[];
      MergeSortHelper(workedArray, 0, nums.Length - 1);
      return workedArray;
    }

    private void MergeSortHelper(int[] nums, int start, int end)
    {
      if (start < end)
      {
        var mid = start + (end - start) / 2;
        MergeSortHelper(nums, start, mid);
        MergeSortHelper(nums, mid + 1, end);
        MergeInPlace(nums, start, end);
      }
    }

    private static void MergeInPlace(int[] input, int left, int right)
    {
      if (left < right)
      {
        var mid = left + (right - left) / 2;
        var l = left;
        var r = mid + 1;
        while (l <= mid && r <= right)
        {
          if (input[l] <= input[r])
          {
            l++;
          }
          else
          {
            //Note: What's happening here is that the the number greater than the index l is being pulled to lth position and the since we have moved the values at indices  we are incrementing the pointers we have had so far.
            /*
             * E.: Let's say we have array 7,10,11 on the left and 5,6 on the right then 7 > 5 hence we are simulation the following.
             * Store value 5 some where then pull the data after 7 upto the point 5 (r points to this)
             * Now copy the value 5 to the place where 7 was sitting earlier this would produce the new arrays as
             * 5,7,10 and 11,6.
             * Now adjust the indices of l, mid, r
             *
             */
            int temp = input[r];

            int rotateIndex = r;
            while (rotateIndex > l)
            {
              input[rotateIndex] = input[rotateIndex - 1];
              rotateIndex--;
            }
            input[l] = temp;
            l++;
            mid++;
            r++;
          }
        }
      }
    }

    #endregion Merge Sort

    [Theory]
    [InlineData("3,2,1,5,6,4", 2, 5)]
    [InlineData("3,2,3,1,2,4,5,5,6", 4, 4)]
    [InlineData("2, 1", 2, 1)]
    public void CanFindKthLargest(string nums, int k, int expected)
    {
      Assert.Equal(expected, FindKthLargest(nums.AsIntsFromCsv(), k));
      //Assert.Equal(new[] { 1, 2, 3, 4, 5, 6 }, MergeSort(new[] { 6, 2, 3, 5, 4, 1 }, 0));
    }
  }
}
