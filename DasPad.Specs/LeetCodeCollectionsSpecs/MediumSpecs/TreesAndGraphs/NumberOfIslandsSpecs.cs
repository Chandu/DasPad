﻿namespace DasPad.Specs.LeetCodeCollectionsSpecs.MediumSpecs.TreesAndGraphs
{
  public class NumberOfIslandsSpecs
  {
    /*
     * Given a 2d grid map of '1's (land) and '0's (water), count the number of islands. An island is surrounded by water and is formed by connecting adjacent lands horizontally or vertically. You may assume all four edges of the grid are all surrounded by water.

        Example 1:

        Input:
        11110
        11010
        11000
        00000

        Output: 1
        Example 2:

        Input:
        11000
        11000
        00100
        00011

        Output: 3
     */

    //Note: Like this DFS solution as it has comments/details

    private int y;          // The height of the given grid
    private int x;          // The width of the given grid
    private char[][] g;     // The given grid, stored to reduce recursion memory usage

    /**
     * Given a 2d grid map of '1's (land) and '0's (water),
     * count the number of islands.
     *
     * This method approaches the problem as one of depth-first connected
     * components search
     * @param grid, the given grid.
     * @return the number of islands.
     */

    //Revisit
    public int NumIslands(char[][] grid)
    {
      // Store the given grid
      // This prevents having to make copies during recursion
      g = grid;

      // Our count to return
      int c = 0;

      // Dimensions of the given graph
      y = g.Length;
      if (y == 0) return 0;
      x = g[0].Length;

      // Iterate over the entire given grid
      for (int i = 0; i < y; i++)
      {
        for (int j = 0; j < x; j++)
        {
          if (g[i][j] == '1')
          {
            dfs(i, j);
            c++;
          }
        }
      }
      return c;
    }

    /**
     * Marks the given site as visited, then checks adjacent sites.
     *
     * Or, Marks the given site as water, if land, then checks adjacent sites.
     *
     * Or, Given one coordinate (i,j) of an island, obliterates the island
     * from the given grid, so that it is not counted again.
     *
     * @param i, the row index of the given grid
     * @param j, the column index of the given grid
     */

    private void dfs(int i, int j)
    {
      // Check for invalid indices and for sites that aren't land
      if (i < 0 || i >= y || j < 0 || j >= x || g[i][j] != '1') return;

      // Mark the site as visited
      g[i][j] = '0';

      // Check all adjacent sites
      dfs(i + 1, j);
      dfs(i - 1, j);
      dfs(i, j + 1);
      dfs(i, j - 1);
    }
  }
}
