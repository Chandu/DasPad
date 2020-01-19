namespace DasPad.Sortings
{
  public static class HeapSorts
  {
    public static void Swap(int[] inputArray, int left, int right)
    {
      var temp = inputArray[left];
      inputArray[left] = inputArray[right];
      inputArray[right] = temp;
    }

    public static int[] HeapSort(int[] input)
    {
      var workedArray = input.Clone() as int[];
      Heapify(workedArray, workedArray.Length - 1);
      Swap(workedArray, 0, workedArray.Length - 1);
      for (var i = workedArray.Length - 2; i >= 0; i--)
      {
        Heapify(workedArray, i);
        Swap(workedArray, 0, i);
      }
      return workedArray;
    }

    public static void Heapify(int[] inputArray, int limitIndex)
    {
      int startWith = (limitIndex / 2) - 1;
      for (var i = startWith; i >= 0; i--)
      {
        var largestIndex = i;
        var leftIndex = (2 * i) + 1;
        var rightIndex = (2 * i) + 2;

        if (leftIndex < limitIndex && inputArray[largestIndex] < inputArray[leftIndex])
        {
          largestIndex = leftIndex;
        }
        if (rightIndex < limitIndex && inputArray[largestIndex] < inputArray[rightIndex])
        {
          largestIndex = rightIndex;
        }

        if (largestIndex != i)
        {
          var temp = inputArray[i];
          inputArray[i] = inputArray[largestIndex];
          inputArray[largestIndex] = temp;
          Heapify(inputArray, limitIndex - i);
        }
      }
    }
  }
}
