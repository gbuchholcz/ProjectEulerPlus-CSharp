using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler6
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
            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                long N = long.Parse(input.ReadLine());

                long a = ((1 + N) * N / 2) * ((1 + N) * N / 2);
                long b = N * (N + 1) * (2 * N + 1) / 6;

                output.WriteLine(a - b);
            }
        }


        public static void Test()
        {
            string inputData = @"2
                                    3
                                    10";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
