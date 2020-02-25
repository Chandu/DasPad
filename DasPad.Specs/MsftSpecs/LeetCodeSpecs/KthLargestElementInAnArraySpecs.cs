using System;
using Xunit;

namespace DasPad.Specs.MsftSpecs.LeetCodeSpecs
{
  public class KthLargestElementInAnArraySpecs
  {
    /*
     * https://leetcode.com/problems/kth-largest-element-in-an-array/
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
      return sorted[k - 1];
      //return kthsmallest(nums, 0, nums.Length - 1, k);
    }

    #region GFG Solution

    private static int kthsmallest(int[] arr, int l, int r, int k)
    {
      // If k is smaller than number of elements in array
      if (k > 0 && k <= r - l + 1)
      {
        // partitioning the array along the pivot
        int pos = randomPartition(arr, l, r);

        // check if current element gives you the kth smallest element
        if (pos - l == k - 1)
          return arr[pos];

        // else recurse for the left and right half accordingly
        if (pos - l > k - 1)
          return kthsmallest(arr, l, pos - 1, k);
        return kthsmallest(arr, pos + 1, r, k - pos + l - 1);
      }

      return int.MaxValue;
    }

    private static int partition(int[] arr, int l, int r)
    {
      int x = arr[r], i = l;
      for (int j = l; j <= r - 1; j++)
      {
        if (arr[j] <= x)
        {
          int tempInner = arr[j];
          arr[j] = arr[i];
          arr[i] = tempInner;
          i++;
        }
      }
      int temp = arr[r];
      arr[r] = arr[i];
      arr[i] = temp;
      return i;
    }

    // Function to partition the array along the random pivot
    private static int randomPartition(int[] arr, int l, int r)
    {
      Random rand = new Random();
      int n = r - l + 1;
      int pivot = rand.Next(0, n);
      int temp = arr[r];
      arr[r] = arr[l + pivot];
      arr[l + pivot] = temp;

      return partition(arr, l, r);
    }

    #endregion GFG Solution

    private int[] Sort(int[] nums, int limit)
    {
      return HeapSort(nums);
    }

    #region HeapSort

    private void Heapify(int[] nums, int startIndex, int endIndex, Func<int, int, bool> compareFn)
    {
      var leftIndex = 2 * startIndex + 1;
      var rightIndex = 2 * startIndex + 2;
      var largestIndex = startIndex;
      if (leftIndex <= endIndex && compareFn(nums[leftIndex], nums[largestIndex]))
      {
        largestIndex = leftIndex;
      }
      if (rightIndex <= endIndex && compareFn(nums[rightIndex], nums[largestIndex]))
      {
        largestIndex = rightIndex;
      }
      if (startIndex != largestIndex)
      {
        Swap(nums, largestIndex, startIndex);
        Heapify(nums, largestIndex, endIndex, compareFn);
      }
    }

    private int[] HeapSort(int[] nums)
    {
      int[] workedArray = nums.Clone() as int[];
      //Tip: Here we are building the heap of the raw iput array and we are starting with non leaf nodes and heapifying each of the node. By the end of this process we will have the max/min value at the root.
      //One the heap is built we can then simple remove the root(swap it with last element) and heapify it from the root upto the last - 1 element.
      for (var i = workedArray.Length / 2; i >= 0; i--)
      {
        Heapify(workedArray, i, workedArray.Length - 1, (a, b) => a < b);
      }
      for (var i = workedArray.Length - 1; i > 0; i--)
      {
        Swap(workedArray, 0, i);
        Heapify(workedArray, 0, i - 1, (a, b) => a < b);
      }
      return workedArray;
    }

    #endregion HeapSort

    private void Swap(int[] nums, int left, int right)
    {
      var temp = nums[left];
      nums[left] = nums[right];
      nums[right] = temp;
    }

    [Theory]
    [InlineData(5, 2, 3, 2, 1, 5, 6, 4)]
    [InlineData(4, 4, 3, 2, 3, 1, 2, 4, 5, 5, 6)]
    public void CanFindKthLargest(int expected, int k, params int[] nums)
    {
      Assert.Equal(expected, FindKthLargest(nums, k));
    }
  }
}
