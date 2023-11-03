namespace CrackingTheCodeInterview.DP
{
    public class TripleStep
    {
        int[] memo = new int[1000];
        public int StepCount(int n)
        {
            if (n == 0) return 1;
            else if (n < 0) return 0;
            if (memo[n] != 0) return memo[n];
            memo[n] = StepCount(n - 1) + StepCount(n - 2) + StepCount(n - 3);
            return memo[n];
        }
    }
}
