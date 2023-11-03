using System;
using System.Collections.Generic;
using System.Text;

namespace LeadCode.Medium
{
    public class UniquePathV2
    {
        #region Recursive + Memolization
        public static int[,] mark;
        public static bool[,] visit;
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            visit = new bool[obstacleGrid.Length, obstacleGrid[0].Length];
            mark = new int[obstacleGrid.Length, obstacleGrid[0].Length];
            return possiblePath(obstacleGrid, 0, 0);
        }
        public int possiblePath(int[][] mat, int i, int j)
        {
            try
            {
                if (mat[i][j] == 1) return 0;
                if (i == mat.Length - 1 && j == mat[0].Length - 1) return 1;
                if (visit[i, j]) return mark[i, j];
                mark[i, j] = possiblePath(mat, i + 1, j) + possiblePath(mat, i, j + 1);
                visit[i, j] = true;
                return mark[i, j];
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        #endregion

        #region Tabular
        public int UniquePathsWithObstaclesTabular(int[][] obstacleGrid)
        {
            int[,] dp = new int[obstacleGrid.Length, obstacleGrid[0].Length];
            dp[0, 0] = obstacleGrid[0][0] == 1 ? 0 : 1;

            for (int i = 0; i < obstacleGrid.Length; i++)
            {
                for (int j = i == 0 ? 1 : 0; j < obstacleGrid[i].Length; j++)
                {
                    if (obstacleGrid[i][j] == 1)
                        dp[i, j] = 0;
                    else
                        dp[i, j] = ((i - 1 < 0) ? 0 : dp[i - 1, j]) + ((j - 1) < 0 ? 0 : dp[i, j - 1]);
                }
            }
            return dp[obstacleGrid.Length - 1, obstacleGrid[0].Length - 1];
        }
        #endregion
    }
}
