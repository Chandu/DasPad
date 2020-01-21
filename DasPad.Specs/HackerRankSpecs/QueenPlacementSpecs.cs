﻿using System;
      /* Check this row on left side */
      for (i = 0; i < col; i++)

      /* Check upper diagonal on left side */
      for (i = row, j = col; i >= 0 && j >= 0; i--, j--)

      /* Check lower diagonal on left side */
      for (i = row, j = col; j >= 0 && i < boardSize; i++, j--)
      for (int i = 0; i < GetBoardSize(board); i++)
        if (IsPlacementSafe(board, i, col))
          /* Place this queen in board[i,col] */
          board[i, col] = 1;

          /* recur to place rest of the queens */
          if (FindQueenPositionsInternal(board, col + 1, i))
          board[i, col] = 0; // BACKTRACK
        }