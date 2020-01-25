using System;

namespace DasPad.Sortings
{
  public static class MergeSorts
  {
    public static void MergeInPlace(int[] input, int left, int right)
    {
      int mid = (left + right) / 2;
      if (left < right)
      {
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
            int temp = input[r];
            //Revisit: Logic requires second look
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

    public static int[] MergeSortInPlace(int[] inputArray)
    {
      var workedArray = inputArray.Clone() as int[];
      MergeSortInPlaceInternal(workedArray, 0, workedArray.Length - 1);
      return workedArray;
    }

    public static void MergeSortInPlaceInternal(int[] input, int l, int h)
    {
      if (l == h)
      {
        return;
      }

      if (l > h)
      {
        throw new Exception("L is greater than H." + l + " > " + "h");
      }

      var middle = (l + h) / 2;
      MergeSortInPlaceInternal(input, l, middle);
      MergeSortInPlaceInternal(input, middle + 1, h);
      MergeInPlace(input, l, h);
    }

    public static int[] Merge(int[] left, int[] right)
    {
      var output = new int[left.Length + right.Length];
      int i = 0, j = 0, k = 0;

      while (i < left.Length && j < right.Length)
      {
        if (left[i] > right[j])
        {
          output[k++] = right[j];
          j++;
        }
        else
        {
          output[k++] = left[i];

          i++;
        }
      }

      while (i < left.Length)
      {
        output[k++] = left[i];
        i++;
      }

      while (j < right.Length)
      {
        output[k++] = right[j];
        j++;
      }

      return output;
    }

    public static int[] MergeSortInternal(int[] input, int l, int h)
    {
      int m = (l + h) / 2;
      if (l == h)
      {
        return new[]
        {
          input[l]
        };
      }

      if (l > h)
      {
        throw new Exception("L is greater than H." + l + " > " + "h");
      }

      var left = MergeSortInternal(input, l, m);
      var right = MergeSortInternal(input, m + 1, h);
      return Merge(left, right);
    }

    public static int[] MergeSort(int[] input)
    {
      return MergeSortInternal(input, 0, input.Length - 1);
    }
  }
}
