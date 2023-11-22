using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEular
{
    public class Euler15
    {
        static long[,] ans = new long[100, 100];
        static bool[,] visit = new bool[100, 100];
        public long WayCount(long n, long m, long i, long j)
        {
            if (i == n && j == m)
                return 1;
            else if (i > n || j > m)
                return 0;

            if (visit[i, j])
                return ans[i, j];

            visit[i, j] = true;
            ans[i, j] = WayCount(n, m, i, j + 1) + WayCount(n, m, i + 1, j);

            return ans[i, j];
        }
    }
}
