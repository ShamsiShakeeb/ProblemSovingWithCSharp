using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeadCode.Medium
{
    /// <summary>
    /// This Problem Also Visible at Project Eular 81
    /// </summary>
    public class MinimumPathSum
    {
        #region Recursive + Memo https://www.youtube.com/watch?v=t1shZ8_s6jc
        public int MinPathSum(int[][] grid)
        {
            dp = new int[grid.GetLength(0), grid.GetLength(1)];
            visit = new bool[grid.GetLength(0), grid.GetLength(1)];
            return GridTraverse(grid, 0, 0);
        }

        static int[,] dp;
        static bool[,] visit;
        public int GridTraverse(int[][] grid, int i, int j)
        {

            if (i == grid.Length - 1 && j == grid[0].Length - 1)
            {
                return grid[i][j];
            }
            if (i == grid.GetLength(0) || j == grid.GetLength(1))
            {
                return int.MaxValue;
            }
            if (visit[i, j]) return dp[i, j];

            dp[i, j] = grid[i][j] + Math.Min(GridTraverse(grid, i, j + 1), GridTraverse(grid, i + 1, j));
            visit[i, j] = true;
            return dp[i, j];
        }
        #endregion

        #region Tabular https://www.youtube.com/watch?v=pGMsrvt0fpk&t=94s

        public int MinPathSumTabular(int[][] grid)
        {
            int[,] dp = new int[grid.Length, grid[0].Length];

            dp[0, 0] = grid[0][0];

            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = i == 0 ? 1 : 0; j < grid[0].Length; j++)
                {
                    dp[i, j] = grid[i][j];
                    dp[i, j] = dp[i, j] + Math.Min(i - 1 < 0 ? int.MaxValue : dp[i - 1, j], j - 1 < 0 ? int.MaxValue : dp[i, j - 1]);
                }
            }
            return dp[grid.Length - 1, grid[0].Length - 1];
        }

        #endregion
    }
}
