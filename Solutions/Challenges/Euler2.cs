using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler2
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
            long[] fib = new long[90];
            fib[0] = 1;
            fib[1] = 2;
            for (int i = 2; i < fib.Length; ++i)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
            }

            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                long N = long.Parse(input.ReadLine());
                long result = 0;
                for (int i = 1; fib[i] <= N; ++i)
                {
                    if (fib[i] % 2 == 0) result += fib[i];
                }
                output.WriteLine(result);
            }
        }

        public static void Test()
        {
            string inputData = @"2
                                10
                                100";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
