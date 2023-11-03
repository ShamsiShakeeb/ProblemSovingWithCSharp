using System;
using System.Collections.Generic;
using System.Text;

namespace LeadCode.Medium
{
    public class UniquePath
    {
        #region UniquePath Recursive

        static int[,] memo;
        public static int UniquePathsR(int m, int n)
        {
            memo = new int[m, n];
            return Path(0, 0, m, n);
        }
        public static int Path(int i, int j, int m, int n)
        {
            if (i >= m || j >= n) return 0;

            else if (i == m - 1 && j == n - 1) return 1;

            if (memo[i, j] != 0) return memo[i, j];
            memo[i, j] = Path(i + 1, j, m, n) + Path(i, j + 1, m, n);
            return memo[i, j];
        }

        #endregion

        #region Tabular

        public int UniquePathsTabular(int m, int n)
        {
            int[,] dp = new int[m, n];
            dp[0, 0] = 1;

            for (int i = 0; i < m; i++)
            {
                for (int j = i == 0 ? 1 : 0; j < n; j++)
                {
                    dp[i, j] = ((j - 1) < 0 ? 0 : dp[i, j - 1]) + ((i - 1) < 0 ? 0 : dp[i - 1, j]);
                }
            }
            return dp[m - 1, n - 1];
        }

        #endregion
    }
}
