using System;using Xunit;namespace DasPad.Specs.HackerRankSpecs{
  public class QueenPlacementSpecs
  {
    public static int GetBoardSize(int[,] board)
    {
      return (int)Math.Sqrt(board.Length);
    }

    public int[,] FindQueenPositions(int boardSize)
    {
      var toReturn = new int[boardSize, boardSize];
      FindQueenPositionsInternal(toReturn, 0, 0);
      return toReturn;
    }

    public static bool IsPlacementSafe(int[,] board, int row, int col)
    {
      int i, j;
      int boardSize = GetBoardSize(board);
      /* Check this row on left side */
      for (i = 0; i < col; i++)
      {
        if (board[row, i] == 1)
        {
          return false;
        }
      }

      /* Check upper diagonal on left side */
      for (i = row, j = col; i >= 0 && j >= 0; i--, j--)
      {
        if (board[i, j] == 1)
        {
          return false;
        }
      }

      /* Check lower diagonal on left side */
      for (i = row, j = col; j >= 0 && i < boardSize; i++, j--)
      {
        if (board[i, j] == 1)
        {
          return false;
        }
      }

      return true;
    }

    public bool FindQueenPositionsInternal(int[,] board, int col, int lastRow)
    {
      if (col >= GetBoardSize(board))
      {
        return true;
      }      /* Consider this column and try placing        this queen in all rows one by one */
      for (int i = 0; i < GetBoardSize(board); i++)
      {        /* Check if the queen can be placed on        board[i,col] */
        if (IsPlacementSafe(board, i, col))
        {
          /* Place this queen in board[i,col] */
          board[i, col] = 1;

          /* recur to place rest of the queens */
          if (FindQueenPositionsInternal(board, col + 1, i))
          {
            return true;
          }          /* If placing queen in board[i,col]          doesn't lead to a solution then          remove queen from board[i,col] */
          board[i, col] = 0; // BACKTRACK
        }
      }

      return false;
    }

    public static string ArrayToString(int[,] arr)
    {
      var toReturn = "";
      for (var i = 0; i < GetBoardSize(arr); i++)
      {
        for (var j = 0; j < GetBoardSize(arr); j++)
        {
          toReturn += arr[i, j].ToString() + " ";
        }
        toReturn += Environment.NewLine;
      }
      return toReturn;
    }

    [Fact]
    public void CanFindQueenPositions()
    {
      var expected = new int[,]
        {          {0,0,1,0},          {1,0,0,0},          {0,0,0,1},          {0,1,0,0}
        };
      var actual = FindQueenPositions(4);
      Assert.Equal(ArrayToString(expected), ArrayToString(actual));
    }
  }}
