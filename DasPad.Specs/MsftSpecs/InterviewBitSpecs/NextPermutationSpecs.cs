using System.Collections.Generic;
using System.Linq;

namespace DasPad.Specs.MsftSpecs.InterviewBitSpecs
{
  public class NextPermutationSpecs
  {
    /*
     *https://www.interviewbit.com/problems/next-permutation/
     * Next Permutation
      Asked in:
      Microsoft
      Amazon
      Implement the next permutation, which rearranges numbers into the numerically next greater permutation of numbers for a given array A of size N.

      If such arrangement is not possible, it must be rearranged as the lowest possible order i.e., sorted in an ascending order.

      Note:

      1. The replacement must be in-place, do **not** allocate extra memory.
      2. DO NOT USE LIBRARY FUNCTION FOR NEXT PERMUTATION. Use of Library functions will disqualify your submission retroactively and will give you penalty points.
      Input Format:

      The first and the only argument of input has an array of integers, A.
      Output Format:

      Return an array of integers, representing the next permutation of the given array.
      Constraints:

      1 <= N <= 5e5
      1 <= A[i] <= 1e9
      Examples:

      Input 1:
          A = [1, 2, 3]

      Output 1:
          [1, 3, 2]
      Input 2:
          A = [3, 2, 1]

      Output 2:
          [1, 2, 3]
      Input 3:
          A = [1, 1, 5]

      Output 3:
          [1, 5, 1]
      Input 4:
          A = [20, 50, 113]

      Output 4:
          [20, 113, 50]
     */
    //Note://https://leetcode.com/problems/next-permutation/solution/
    /*
     * First, we observe that for any given sequence that is in descending order, no next larger permutation is possible. For example, no next permutation is possible for the following array:

      [9, 5, 4, 3, 1]
      We need to find the first pair of two successive numbers a[i] and a[i−1], from the right, which satisfy a[i] > a[i-1]. Now, no rearrangements to the right of a[i-1] can create a larger permutation since that subarray consists of numbers in descending order. Thus, we need to rearrange the numbers to the right of a[i-1] including itself.

      Now, what kind of rearrangement will produce the next larger number? We want to create the permutation just larger than the current one. Therefore, we need to replace the number a[i-1] with the number which is just larger than itself among the numbers lying to its right section, say a[j].

      We swap the numbers a[i-1] and a[j]. We now have the correct number at index i-1. But still the current permutation isn't the permutation that we are looking for. We need the smallest permutation that can be formed by using the numbers only to the right of a[i-1]. Therefore, we need to place those numbers in ascending order to get their smallest permutation.

      But, recall that while scanning the numbers from the right, we simply kept decrementing the index until we found the pair a[i] and a[i-1] where, a[i] > a[i-1]. Thus, all numbers to the right of a[i-1]a[i−1] were already sorted in descending order. Furthermore, swapping a[i-1] and a[j] didn't change that order. Therefore, we simply need to reverse the numbers following a[i-1] to get the next smallest lexicographic permutation.
     */

    public List<int> nextPermutation(List<int> A)
    {
      int i = A.Count() - 2;
      while (i >= 0 && A[i + 1] <= A[i])
      {
        i--;
      }
      if (i >= 0)
      {
        int j = A.Count() - 1;
        while (j >= 0 && A[j] <= A[i])
        {
          j--;
        }
        swap(A, i, j);
      }
      reverse(A, i + 1);
      return A;
    }

    private void reverse(List<int> nums, int start)
    {
      int i = start, j = nums.Count() - 1;
      while (i < j)
      {
        swap(nums, i, j);
        i++;
        j--;
      }
    }

    private void swap(List<int> nums, int i, int j)
    {
      int temp = nums[i];
      nums[i] = nums[j];
      nums[j] = temp;
    }
  }
}
