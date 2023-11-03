using System;
using System.Collections.Generic;
using System.Text;

namespace CrackingTheCodeInterview.DP
{
    public class RecursiveMultiply
    {

        public int MultiplyOfTwoValue(int x , int y)
        {
            counter = (y>0)?1:0-1;
            if (x == 0 || y == 0) return 0;
            var ans = Multiply(x,y);
            root = 0;
            return ans;
        }

        private static int counter;
        private static int root = 0;
        private static int Multiply(int x, int y)
        {
            if (counter == 1)
            {
                root = x;
            }
            else if (counter == -1)
            {
                x = 0-x;
                root = x;
            }

            if (counter == y) 
                return x;
           
            if (y > 0) 
                counter++;
            else 
                counter--;

            return Multiply(x + root, y);
        }
    }
}
