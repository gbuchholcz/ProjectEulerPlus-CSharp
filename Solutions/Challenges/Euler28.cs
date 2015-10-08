using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler28
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
                long mod = 1000000007L;
                long invmod_6 = 166666668L;
                long invmod_2 = 500000004L;
                long i = ((N - 1) / 2) % mod;
                long i2 = i * i % mod;
                long i3 = i2 * i % mod;
                long sum_i = (i2 + i) % mod * invmod_2 % mod;
                long sum_i2 = ((i2 * 3 % mod + i3 * 2 % mod) % mod + i) % mod * invmod_6 % mod;
                long result = (((i * 4 % mod + sum_i * 4 % mod) % mod + sum_i2 * 16 % mod) % mod + 1) % mod;

                output.WriteLine(result.ToString());

            }
        }


        public static void Test()
        {
            string inputData = @"2
3
5";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
