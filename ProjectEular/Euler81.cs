using System;

namespace ProjectEular
{
    public class Euler81
    {
        #region Tabular
        public static int MinPathSum(int[][] grid)
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

        #region Eular81 & LeetCode64 recursion + momo
        static int[,] dp;
        static bool[,] visit;
        public static int MinPathSum(int[][] grid, int i, int j, int n, int m)
        {
            if (i == n || j == m) return int.MaxValue;

            if (i == n - 1 && j == m - 1)
                return grid[i][j];

            if (visit[i, j])
                return dp[i, j];

            dp[i, j] = grid[i][j] + Math.Min(MinPathSum(grid, i + 1, j, n, m), MinPathSum(grid, i, j + 1, n, m));
            visit[i, j] = true;
            return dp[i, j];
        }

        public int MinPathSumMain(int[][] grid)
        {
            dp = new int[grid.Length, grid[0].Length];
            visit = new bool[grid.Length, grid[0].Length];
            return MinPathSum(grid, 0, 0, grid.Length, grid[0].Length);
        }

        #endregion
    }
}
