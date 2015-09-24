using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler29
    {
        static void main(String[] args)
        {
            using (System.IO.StreamReader input = new System.IO.StreamReader(Console.OpenStandardInput()))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }

        private static void Solve(System.IO.TextReader input, System.IO.TextWriter output)
        {
            long N = long.Parse(input.ReadLine());

            int maxQuotient = (int)Math.Log(N, 2);
            int[] duplicateCounter = new int[maxQuotient * N + 1];
            int[] distinctCounter = new int[maxQuotient];
            for (int i = 1; i <= maxQuotient; ++i)
            {
                for (int j = 2; j <= N; ++j)
                {
                    ++duplicateCounter[i * j];
                }
                for (int j = 2; j < duplicateCounter.Length; ++j)
                {
                    if (duplicateCounter[j] > 0) ++distinctCounter[i - 1];
                }
            }

            bool[] rowAlreadyVisited = new bool[N];
            long result = 0;
            for (int i = 0; i < N - 1; ++i)
            {
                if (!rowAlreadyVisited[i])
                {
                    int level = 0;
                    long q = i + 2;
                    for (long e = i + 2; e <= N; rowAlreadyVisited[e - 2] = true, e *= q, ++level) ;
                    result += distinctCounter[--level];
                }
            }

            output.WriteLine(result);            
        }


        public static void Test()
        {
            string inputData = @"100000";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
