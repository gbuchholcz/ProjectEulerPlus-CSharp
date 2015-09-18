using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler10
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
            int maxN = 1000000;
            List<long> primes = new List<long>() { 2 };
            List<long> accSum = new List<long>() { 2 };

            for (int i = 3; i <= maxN; ++i)
            {
                bool isPrime = true;
                long maxDivisor = Convert.ToInt64(Math.Sqrt(i));
                for (int j = 0; j < primes.Count() && primes[j] <= maxDivisor; ++j)
                {
                    if (i % primes[j] == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    primes.Add(i);
                    accSum.Add(accSum.Last() + i);
                }
            }

            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                int N = int.Parse(input.ReadLine());
                int ix = primes.BinarySearch(N);
                ix = ix >= 0 ? ix : (-ix - 2);
                output.WriteLine(accSum[ix]);
            }
        }

        public static void Test()
        {
            string inputData = @"2
                                    5
                                    10";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
