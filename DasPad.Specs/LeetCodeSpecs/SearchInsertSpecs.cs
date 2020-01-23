using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
    public class SearchInsertSpecs
    {
        public int SearchInsert(int[] nums, int target)
        {
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] >= target)
                {
                    return i;
                }
            }
            return nums.Length;
        }

        [Fact]
        public void CanSearchInsert()
        {
            var input = new[] { 1, 3, 5, 6 };
            Assert.Equal(2, SearchInsert(input, 5));
            Assert.Equal(1, SearchInsert(input, 2));
            Assert.Equal(4, SearchInsert(input, 7));
            Assert.Equal(0, SearchInsert(input, 0));
        }
    }
}