using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            SortedDictionary<long, long> tripletCountByPerimeter = new SortedDictionary<long, long>();
            for (long p = 12; p < 5000000; p += 2)
            {
                long maxM = 1L + (long)Math.Sqrt(p >> 1);
                for (long m = 2; m < maxM; ++m)
                {
                    if ((p/2) % m == 0)
                    {
                        if (tripletCountByPerimeter.ContainsKey(p))
                        {
                            ++tripletCountByPerimeter[p];
                        }
                        else
                        {
                            tripletCountByPerimeter[p] = 1;
                        }
                    }
                }
            }
            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                int N = int.Parse(input.ReadLine());

            }
        }

        private static long Sqrt(long n)
        {
            long s = (long)(Math.Sqrt(n) + 0.5);
            return s;
        }


        private static bool IsSquareNumber(long n)
        {
            long s = (long)(Math.Sqrt(n) + 0.5);
            return s * s == n;
        }

        public static void Test()
        {
            string inputData = @"2
                                    12
                                    5000000";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
