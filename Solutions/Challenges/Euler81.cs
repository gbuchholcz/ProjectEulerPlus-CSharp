using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler81
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
            int N = int.Parse(input.ReadLine());
            long[][] m = new long[N][];
            for (int i = 0; i < N; ++i)
            {
                m[i] = ReadLongArray(input);
            }

            for (int i = 0; i < N; ++i)
            {
                for (int j = 0; j < N; ++j)
                {
                    if (i == 0 && j == 0) continue;
                    long min1 = i == 0 ? long.MaxValue : m[i - 1][j];
                    long min2 = j == 0 ? long.MaxValue : m[i][j - 1];
                    m[i][j] += Math.Min(min1, min2);
                }
            }

            output.WriteLine(m[N - 1][N - 1]);
        }

        static long[] ReadLongArray(System.IO.TextReader reader)
        {
            return System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Select(reader.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries), x => long.Parse(x)));
        }

        public static void Test()
        {
            string inputData = @"5
                                131 673 234 103 18
                                201 96 342 965 150
                                630 803 746 422 111
                                537 699 497 121 956
                                805 732 524 37 331";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
