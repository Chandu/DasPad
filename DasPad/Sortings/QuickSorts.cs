namespace DasPad.Sortings
{
  public class QuickSorts
  {
    public static int[] QuickSortInPlace(int[] input)
    {
      var workedArray = input.Clone() as int[];
      QuickSortInternalInPlace(workedArray, 0, input.Length - 1);
      return workedArray;
    }

    public static void QuickSortInternalInPlace(int[] input, int low, int high)
    {
      if (low < high)
      {
        var p = PartitionInPlace(input, low, high);
        QuickSortInternalInPlace(input, low, p - 1);
        QuickSortInternalInPlace(input, p + 1, high);
      }
    }

    public static int PartitionInPlace(int[] input, int low, int high)
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
          int temp = input[i];
          input[i] = input[j];
          input[j] = temp;
        }
      }

      // swap arr[i+1] and arr[high] (or pivot)
      int temp1 = input[i + 1];
      input[i + 1] = input[high];
      input[high] = temp1;

      return i + 1;
    }
  }
}
