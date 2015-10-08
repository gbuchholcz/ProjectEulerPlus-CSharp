using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Solutions.Challenges
{
    class Euler39
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
            int maxP = 5000000;
            int maxM = (int)(Math.Sqrt(maxP) / 2.0 + 0.1);
            int maxN = (int)(Math.Sqrt(maxP) / 4.0 + 0.1);
            List<int> relevantPerimeters = new List<int>();
            int[] allTripleCounts = new int[maxP + 1];


            for (int n = 1; n < maxN; ++n)
            {
                for (int m = n + 1; m < maxM; ++m)
                {
                    if (Gcd(m, n) == 1 && (m - n) % 2 == 1)
                    {
                        int p = (m * m + m * n) << 1;
                        for (int pp = p; pp < maxP; pp += p)
                            ++allTripleCounts[pp];
                    }
                }
            }

            int maxTripleCountSoFar = 0;
            for (int i = 2; i <= maxP; i += 2)
            {
                if (maxTripleCountSoFar < allTripleCounts[i])
                {
                    maxTripleCountSoFar = allTripleCounts[i];
                    relevantPerimeters.Add(i);
                }
            }

            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                int N = int.Parse(input.ReadLine());
                int pos = relevantPerimeters.BinarySearch(N);
                if (pos < 0)
                {
                    pos = ~pos;
                    pos--;
                }
                output.WriteLine(relevantPerimeters[pos]);
            }
        }

        public static void Test()
        {
            string inputData = @"2
12
80";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }

        private static int Gcd(int a, int b)
        {
            int tmp;
            while (b != 0)
            {
                tmp = a % b;
                a = b;
                b = tmp;
            }
            return a;
        }

    }

}
