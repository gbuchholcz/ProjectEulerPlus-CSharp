using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Solutions.Challenges
{
    class Euler44
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
            long[] pars = input.ReadLine().Split().Select(i => long.Parse(i)).ToArray();
            long N = pars[0] - 1;
            long K = pars[1];
            long p1, p2;
            for (long n = K; n < N; ++n)
            {
                p1 = P(n);
                p2 = P(n - K);
                if (IsPentagonal(p1 - p2) || IsPentagonal(p1 + p2))
                {
                    output.WriteLine(p1);
                }
            }

        }

        private static long P(long n)
        {
            ++n;
            return (3 * n * n - n) >> 1;
        }

        private static bool IsPentagonal(long x)
        {
            long sqrt = (long)(Math.Sqrt(1 + 24 * x) + 0.1);
            if (sqrt * sqrt == 1 + 24 * x)
            {
                if ((sqrt + 1) % 6 == 0)
                return true;
            }
            return false;
        }


        public static void Test()
        {
            string inputData = @"10 2";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }


    }

}
