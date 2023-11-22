using LeadCode.Medium;
using ProjectEular;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AcmProblemSolving
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            //Do Code
            Console.WriteLine(new Euler15().WayCount(20,20, 0, 0));
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("Time: "+elapsedMs +" ms");

        }

    }
}


