using System;
using Xunit;

namespace DasPad.Specs.LeetCodeSpecs
{
    public class PrisonCellChangeSpecs
    {
        public int[] PrisonAfterNDays(int[] cells, int N)
        {
            if (cells.Length == 0)
            {
                return Array.Empty<int>();
            }

            var workedCells = cells.Clone() as int[];

            for (var j = 0; j < N; j++)
            {
                var curCells = workedCells.Clone() as int[];

                for (int i = 1; i < workedCells.Length - 1; i++)
                {
                    var left = curCells[i - 1];
                    var right = curCells[i + 1];
                    if ((left ^ right) == 0)
                    {
                        workedCells[i] = 1;
                    }
                    else
                    {
                        workedCells[i] = 0;
                    }
                }
            }

            return workedCells;
        }

        [Fact]
        public void CanChange()
        {
            var input = new[]
            {
        0,1,0,1,1,0,0,1
      };
            var actual = PrisonAfterNDays(input, 1);
            //Assert.Equal(new[] { 0, 0, 1, 1, 0, 0, 0, 0 }, actual);
            //Assert.Equal(new[] { 0, 1, 1, 0, 0, 0, 0, 0 }, actual);
        }
    }
}