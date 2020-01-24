using System.Linq;
using Xunit;

namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.BacktrackingSpecs
{
  public class WordSearchSpecs
  {
    /*
     * https://leetcode.com/explore/interview/card/top-interview-questions-medium/109/backtracking/797/
     * Given a 2D board and a word, find if the word exists in the grid.

      The word can be constructed from letters of sequentially adjacent cell, where "adjacent" cells are those horizontally or vertically neighboring. The same letter cell may not be used more than once.

      Example:

      board =
      [
        ['A','B','C','E'],
        ['S','F','C','S'],
        ['A','D','E','E']
      ]

      Given word = "ABCCED", return true.
      Given word = "SEE", return true.
      Given word = "ABCB", return false.
     */

    public bool Exist(char[][] board, string word)
    {
      if (board.Length == 0 || board[0].Length == 0)
      {
        return false;
      }
      for (var i = 0; i < board.Length; i++)
      {
        for (var j = 0; j < board[i].Length; j++)
        {
          var dfsResult = Dfs(board, word, 0, i, j);
          if (dfsResult)
          {
            return dfsResult;
          }
        }
      }
      return false;
    }

    private static int[][] Movements = new[]
    {
      new [] {0, -1 }, //Left
      new [] {0, 1 }, //Right
      new [] {-1, 0 },//Top
      new [] {1, 0 },//Bottom
    };

    public bool Dfs(char[][] board, string word, int startSearchForCharIndexInWord, int i, int j)
    {
      if (startSearchForCharIndexInWord == word.Length)
      {
        return true;
      }
      else
      {
        if (i < 0 || j < 0 || i >= board.Length || j >= board[i].Length)
        {
          return false;
        }
        if (board[i][j] == '#' || board[i][j] != word[startSearchForCharIndexInWord])
        {
          return false;
        }
        var curChar = board[i][j];
        board[i][j] = '#';
        var toReturn = Movements.Any(a => Dfs(board, word, startSearchForCharIndexInWord + 1, i + a[0], j + a[1]));
        board[i][j] = curChar;
        return toReturn;
      }
    }

    [Theory]
    [InlineData("ABCCED", true)]
    [InlineData("SEE", true)]
    [InlineData("ABCB", false)]
    public void CanExist(string input, bool expected)
    {
      var board = new[] {
        new [] {'A','B','C','E'},
        new [] {'S','F','C','S'},
        new [] {'A','D','E','E'}
      };

      Assert.Equal(expected, Exist(board, input));
    }
  }
}
