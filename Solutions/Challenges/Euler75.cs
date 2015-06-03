using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler75
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
            /*Collect all test values*/
            List<int> testValues = new List<int>();
            int maxTestValue = int.MinValue;
            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                int N = int.Parse(input.ReadLine());
                maxTestValue = N > maxTestValue ? N : maxTestValue;
                testValues.Add(N);
            }

            /*Count the proper triangles and store the value in an array*/
            long[] results = new long[maxTestValue + 1];
            int max = (int)Math.Floor(Math.Sqrt(maxTestValue >> 1));
            for (int n = 1; n <= max; ++n)
            {
                for (int m = n; m <= max; ++m)
                {
                    if ((m - n) % 2 == 1 && AreCoPrimes(m, n))
                    {

                        int a = (m * n) << 1;
                        int b = m * m - n * n;
                        int c = m * m + n * n;

                        int p = a + b + c;

                        while (p <= maxTestValue)
                        {
                            ++results[p];
                            p += a + b + c;
                        }
                    }
                }
            }

            /*Accumulate the results*/
            long result = 0;
            for (int i = 1; i <= maxTestValue; ++i)
            {
                result += results[i] == 1 ? 1 : 0;
                results[i] = result;

            }
            foreach (var testValue in testValues)
            {
                output.WriteLine(results[testValue]);
            }
        }

        static bool AreCoPrimes(int x, int y)
        {

            while (y != 0)
            {
                int t = y;
                y = x % y;
                x = t;
            }
            return x == 1;
        }


        public static void Test()
        {
            string inputData = @"2
                                12
                                50";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
