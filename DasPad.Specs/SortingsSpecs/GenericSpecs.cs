using DasPad.Sortings;
using System;
using System.Linq;
using Xunit;

namespace DasPad.Specs.SortingsSpecs
{
  public class GenericSpecs
  {
    private void SortTheoryInternal(int[] input, object expected, Func<int[], int[]> sortFn)
    {
      if (expected is Exception)
      {
        Assert.Throws(expected.GetType(), () => sortFn(input));
      }
      else
      {
        Assert.Equal(expected, sortFn(input));
      }
    }

    public static int[] Sort(int[] input)
    {
      var a = input.Clone() as int[];
      Array.Sort(a);
      return a;
    }

    [Fact]
    public void BubbleSortShouldWork()
    {
      SortingsInputs.SimpleInputs.ToList().ForEach(a => SortTheoryInternal(a, Sort(a), CommonSorts.BubbleSort));
    }

    [Fact]
    public void InsertionSortShouldWork()
    {
      SortingsInputs.SimpleInputs.ToList().ForEach(a => SortTheoryInternal(a, Sort(a), CommonSorts.InsertionSort));
    }

    [Fact]
    public void SelectionSortShouldWork()
    {
      SortingsInputs.SimpleInputs.ToList().ForEach(a => SortTheoryInternal(a, Sort(a), CommonSorts.SelectionSort));
    }

    [Fact]
    public void MergeSortShouldWork()
    {
      SortingsInputs.SimpleInputs.ToList().ForEach(a => SortTheoryInternal(a, Sort(a), MergeSorts.MergeSort));
    }

    [Fact]
    public void MergeSortInPlaceShouldWork()
    {
      SortingsInputs.SimpleInputs.ToList().ForEach(a => SortTheoryInternal(a, Sort(a), MergeSorts.MergeSortInPlace));
    }

    [Fact]
    public void QuickSortShouldWork()
    {
      SortingsInputs.SimpleInputs.ToList().ForEach(a => SortTheoryInternal(a, Sort(a), QuickSorts.QuickSortInPlace));
    }

    [Fact]
    public void HeapSortShouldWork()
    {
      var input = new[]
      {
        10, 3, 76, 34, 23, 32
      };
      SortTheoryInternal(input, Sort(input), HeapSorts.HeapSort);
    }

    [Fact]
    public void MergeShouldWorkCorrectly()
    {
      var input = new[]
      {
        1,3,2,4
      };
      var expected = new[] { 1, 2, 3, 4 };
      MergeSorts.MergeInPlace(input, 0, input.Length - 1);
      Assert.Equal(expected, input);
    }

    [Fact]
    public void QuickSortInPlaceShouldWorkCorrectly()
    {
      var input = new[]
      {
       4,3,2,1
      };
      var expected = new[] { 1, 2, 3, 4 };
      var actual = QuickSorts.QuickSortInPlace(input);
      Assert.Equal(expected, actual);
    }
  }
}
