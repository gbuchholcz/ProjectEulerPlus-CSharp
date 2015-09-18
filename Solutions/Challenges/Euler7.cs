using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler7
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
            long[] primes = new long[10000];
            primes[0] = 2;
            int actualPrimeIndex = 1;
            for (int i = 3; actualPrimeIndex < 10000; i += 2)
            {
                bool isPrime = true;
                long maxTest = (long)Math.Sqrt(i) + 1;
                for (int j = 1; j < actualPrimeIndex && primes[j] < maxTest; ++j)
                {
                    if (i % primes[j] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes[actualPrimeIndex++] = i;
                }
            }

            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                long N = long.Parse(input.ReadLine());
                output.WriteLine(primes[N - 1]);
            }
        }

        public static void Test()
        {
            string inputData = @"2
                                    3
                                    6";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
