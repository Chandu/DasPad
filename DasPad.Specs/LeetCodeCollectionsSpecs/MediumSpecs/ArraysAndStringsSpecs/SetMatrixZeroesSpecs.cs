using System;
using System.Collections.Generic;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.ArraysAndStringsSpecs
{
  public class SetMatrixZeroesSpecs
    {
        /*
         * https://leetcode.com/explore/interview/card/top-interview-questions-medium/103/array-and-strings/777/
         * Given a m x n matrix, if an element is 0, set its entire row and column to 0. Do it in-place.

            Example 1:

            Input:
            [
              [1,1,1],
              [1,0,1],
              [1,1,1]
            ]
            Output:
            [
              [1,0,1],
              [0,0,0],
              [1,0,1]
            ]
            Example 2:

            Input:
            [
              [0,1,2,0],
              [3,4,5,2],
              [1,3,1,5]
            ]
            Output:
            [
              [0,0,0,0],
              [0,4,5,0],
              [0,3,1,0]
            ]
            Follow up:

            A straight forward solution using O(mn) space is probably a bad idea.
            A simple improvement uses O(m + n) space, but still not the best solution.
            Could you devise a constant space solution?
         */

        public void SetZeroes(int[][] matrix)
        {
            SetZeroesWithConstantSpace(matrix);
        }

        //TIP: Tricky solution
        public void SetZeroesWithConstantSpace(int[][] matrix)
        {
            //TIP: From the Question hint#4, it suggests we can use first cell of each row and column to maintain a flag for that row... I wonder why...?
            // Couldn't figure out the "why" of he above, so googled it and here it is:
            /*
             * Constant Space Solution:
               Since the problem asks for a constant space solution, we must think of one without allocating additional space. Remember in last solution, we used additional row and column to store the zero information. How about we use the first column and row to save the zero information? It sounds doable. But what about the first or column contains zeros thus needs to be set as zeros as well? We could work around by using a flag to mark the first row or column as zeros. Consequently, the solution can be devised into following steps:

              1. Check the first column and row contains zeros, if yes, mark the flag as true to indicate first row and column need to set to zeros.

              2. Starting from matrix[1][1], check if each element  is zero, if yes, mark the corresponding first row and column elements as zeros.

              3. Check back the first column and row, and set the corresponding elements in the matrix as zero.

              4. Check the first row and column zero flag, if needed, set the first row and column zeros.
             */
            bool isFirstRowZero = false;
            bool isFirstColZero = false;
            for (var i = 0; i < matrix[0].Length; i++)
            {
                if (matrix[0][i] == 0)
                {
                    isFirstRowZero = true;
                }
            }
            for (var i = 0; i < matrix.Length; i++)
            {
                if (matrix[i][0] == 0)
                {
                    isFirstColZero = true;
                }
            }
            for (var i = 1; i < matrix.Length; i++)
            {
                for (var j = 1; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        matrix[i][0] = 0;
                        matrix[0][j] = 0;
                    }
                }
            }
            for (var i = 1; i < matrix.Length; i++)
            {
                for (var j = 1; j < matrix[0].Length; j++)
                {
                    if (matrix[0][j] == 0 || matrix[i][0] == 0)
                    {
                        matrix[i][j] = 0;
                    }
                }
            }

            if (isFirstRowZero)
            {
                for (int i = 0; i < matrix[0].Length; i++)
                {
                    matrix[0][i] = 0;
                }
            }

            if (isFirstColZero)
            {
                for (int j = 0; j < matrix.Length; j++)
                {
                    matrix[j][0] = 0;
                }
            }
        }

        public void SetZeroesWithMPlusNSpace(int[][] matrix)
        {
            var zeroRows = new HashSet<int>();
            var zeroCols = new HashSet<int>();

            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = 0; j < matrix[0].Length; j++)
                {
                    if (matrix[i][j] == 0)
                    {
                        zeroRows.Add(i);
                        zeroCols.Add(j);
                    }
                }
            }

            for (var i = 0; i < matrix.Length; i++)
            {
                for (var j = 0; j < matrix[0].Length; j++)
                {
                    if (zeroCols.Contains(j) || zeroRows.Contains(i))
                    {
                        matrix[i][j] = 0;
                    }
                }
            }
        }

        public static string ArrayToString(int[][] arr)
        {
            var toReturn = "";
            for (var i = 0; i < arr.Length; i++)
            {
                for (var j = 0; j < arr[i].Length; j++)
                {
                    toReturn += arr[i][j].ToString() + " ";
                }
                toReturn += Environment.NewLine;
            }
            return toReturn;
        }

        [Fact]
        public void CanSetZeroes()
        {
            var input = new[]
            {
        new [] { 1,1,1},
        new [] { 1,0,1},
        new [] { 1,1,1}
      };
            var expected = new[]
            {
        new [] { 1,0,1},
        new [] { 0,0,0},
        new [] { 1,0,1}
      };
            SetZeroes(input);
            Assert.Equal(ArrayToString(expected), ArrayToString(input));

            input = new[]
            {
        new[] { 0, 1, 2, 0 },
        new[] { 3, 4, 5, 2 },
        new[] { 1, 3, 1, 5 }
      };

            expected = new[]
            {
        new[] { 0, 0, 0, 0 },
        new[] { 0, 4, 5, 0 },
        new[] { 0, 3, 1, 0 }
      };
            SetZeroes(input);
            Assert.Equal(ArrayToString(expected), ArrayToString(input));
        }
    }
}