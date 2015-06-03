using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler76
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
            int mod = 1000000007;
            int max = 1000;

            int[,] arr = new int[max + 1, max + 1];
            arr[0, 0] = 1;
            arr[1, 1] = 1;
            arr[2, 1] = 1;
            arr[2, 2] = 1;

            for (int i = 3; i <= max; ++i)
            {
                for (int j = 1; j <= i; ++j)
                {
                    long val = 0;
                    for (int l = 0; l <= j; ++l)
                    {
                        val += arr[i - j, l] % mod;
                    }
                    val %= mod;
                    arr[i, j] = (int)val;
                }
            }

            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                int N = int.Parse(input.ReadLine());
                long result = 0;
                for (int i = 0; i < N; ++i)
                {
                    result += arr[N, i] % mod;
                }
                result %= mod;
                Console.WriteLine(result);
            }
        }



        public static void Test()
        {
            string inputData = @"2
                                    1000
                                    6";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
