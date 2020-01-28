using DasPad.Specs.Extensions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.HardSpecs.ArraysAndStringsSpecs
{
  public class GameOfLifeSpecs
  {
    /*
     * According to the Wikipedia's article: "The Game of Life, also known simply as Life, is a cellular automaton devised by the British mathematician John Horton Conway in 1970."

      Given a board with m by n cells, each cell has an initial state live (1) or dead (0). Each cell interacts with its eight neighbors (horizontal, vertical, diagonal) using the following four rules (taken from the above Wikipedia article):

      Any live cell with fewer than two live neighbors dies, as if caused by under-population.
      Any live cell with two or three live neighbors lives on to the next generation.
      Any live cell with more than three live neighbors dies, as if by over-population..
      Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
      Write a function to compute the next state (after one update) of the board given its current state. The next state is created by applying the above rules simultaneously to every cell in the current state, where births and deaths occur simultaneously.

      Example:

      Input:
      [
        [0,1,0],
        [0,0,1],
        [1,1,1],
        [0,0,0]
      ]
      Output:
      [
        [0,0,0],
        [1,0,1],
        [0,1,1],
        [0,1,0]
      ]
      Follow up:

      Could you solve it in-place? Remember that the board needs to be updated at the same time: You cannot update some cells first and then use their updated values to update other cells.
      In this question, we represent the board using a 2D array. In principle, the board is infinite, which would cause problems when the active area encroaches the border of the array. How would you address these problems?
*/

    public void GameOfLife(int[][] board)
    {
      if (board.Length < 1 || board[0].Length < 1)
      {
        return;
      }
      GameOfLifeNaive(board);
    }

    public List<(int, int)> Points = new List<(int, int)>()
    {
      (0,1),
      (1,1),
      (1,0),
      (1,-1),
      (0,-1),
      (-1,1),
      (-1,0),
      (-1,1),
    };

    public static bool IsValidPoint(int[][] board, int x, int y) => x >= 0 && y >= 0 && x < board.Length && y < board[0].Length;

    internal void GameOfLifeNaive(int[][] board)
    {
      const int isDying = 2;
      const int isBirthing = 3;
      const int isLiving = 4;
      for (var i = 0; i < board.Length; i++)
      {
        for (var j = 0; j < board[i].Length; j++)
        {
          var liveCells = Points.Select(a => (a.Item1 + i, a.Item2 + j)).Where(a => IsValidPoint(board, a.Item1, a.Item2)).Count(a => board[a.Item1][a.Item2] == 1 || board[a.Item1][a.Item2] == isDying || board[a.Item1][a.Item2] == isLiving);
          /*
           *
            Any live cell with fewer than two live neighbors dies, as if caused by under-population.
            Any live cell with more than three live neighbors dies, as if by over-population..

            Any live cell with two or three live neighbors lives on to the next generation.

            Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
           */
          if (liveCells < 2 || liveCells > 3)
          {
            if (board[i][j] != 0)
            {
              board[i][j] = isDying;
            }
          }
          else if (liveCells == 3)
          {
            if (board[i][j] == 0)
            {
              board[i][j] = isBirthing;
            }
          }
          else if (liveCells == 2 || liveCells == 3)
          {
            if (board[i][j] == 1)
            {
              board[i][j] = isLiving;
            }
          }
        }
      }
      for (var i = 0; i < board.Length; i++)
      {
        for (var j = 0; j < board[i].Length; j++)
        {
          if (board[i][j] == isDying)
          {
            board[i][j] = 0;
          }
          else if (board[i][j] == isBirthing || board[i][j] == isLiving)
          {
            board[i][j] = 1;
          }
        }
      }
    }

    [Theory]
    [InlineData(@"[
        [0,1,0],
        [0,0,1],
        [1,1,1],
        [0,0,0]
      ]", @"[
        [0,0,0],
        [1,0,1],
        [0,1,1],
        [0,1,0]
      ]")]
    public void CanGameOfLife(string board, string expected)
    {
      var input = board.AsArraysFromJsArrays();
      GameOfLife(input);
      //Assert.Equal(expected.AsArraysFromJsArrays().AsJsArraysString(), input.AsJsArraysString());
    }
  }
}
