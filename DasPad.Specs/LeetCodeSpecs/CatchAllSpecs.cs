using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
  public class CatchAllSpecs
  {
    public int RemoveElement(int[] nums, int val)
    {
      var length = nums.Length;
      var index = 0;
      var swappableIndex = nums.Length - 1;
      var iteration = 0;
      while (iteration < length && swappableIndex >= index)
      {
        if (val == nums[index])
        {
          for (var a = index; a < length - 1; a++)
          {
            nums[a] = nums[a + 1];
          }
          nums[length - 1] = val;
          swappableIndex--;
        }
        else
        {
          index++;
        }
        iteration++;
      }
      return swappableIndex + 1;
    }

    [Fact]
    public void CanRemoveElement()
    {
      Assert.Equal(5, RemoveElement(new[] { 0, 1, 2, 2, 3, 0, 4, 2 }, 2));
    }
  }
}
