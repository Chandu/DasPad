namespace DasPad.Sortings
{
  public static class CommonSorts
  {
    public static int[] BubbleSort(int[] inputArray)
    {
      var workingArray = inputArray.Clone() as int[];
      for (var i = 0; i < workingArray.Length; i++)
      {
        for (var j = i + 1; j < workingArray.Length; j++)
        {
          if (workingArray[i] > workingArray[j])
          {
            var temp = workingArray[i];
            workingArray[i] = workingArray[j];
            workingArray[j] = temp;
          }
        }
      }

      return workingArray;
    }

    public static int[] InsertionSort(int[] inputArray)
    {
      var workingArray = inputArray.Clone() as int[];
      var length = inputArray.Length;
      for (var i = 0; i < length; i++)
      {
        for (var j = i; j > 0; j--)
        {
          if (workingArray[j] < workingArray[j - 1])
          {
            var temp = workingArray[j - 1];
            workingArray[j - 1] = workingArray[j];
            workingArray[j] = temp;
          }
          else
          {
            break;
          }
        }
      }
      return workingArray;
    }

    public static int[] SelectionSort(int[] inputArray)
    {
      var workingArray = inputArray.Clone() as int[];
      var length = workingArray.Length;
      for (var i = 0; i < length; i++)
      {
        for (var j = i; j < length; j++)
        {
          if (workingArray[j] < workingArray[i])
          {
            var temp = workingArray[j];
            workingArray[j] = workingArray[i];
            workingArray[i] = temp;
          }
        }
      }
      return workingArray;
    }
  }
}
