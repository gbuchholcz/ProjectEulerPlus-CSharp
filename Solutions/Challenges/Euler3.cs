using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler3
    {
        static void main(String[] args)
        {
            using (System.IO.StreamReader input = new System.IO.StreamReader(Console.OpenStandardInput()))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }

        static void Solve(System.IO.TextReader input, System.IO.TextWriter output)
        {
            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                long N = long.Parse(input.ReadLine());

                long n = N;
                long i = 2;
                long maxPrime = 0;
                while (i <= Math.Sqrt(n))
                {
                    if (n % i == 0)
                    {
                        maxPrime = i;
                        n = n / i;
                        i = 2;
                        continue;
                    }
                    ++i;
                }
                output.WriteLine(maxPrime < n ? n : maxPrime);
            }

        }

        public static void Test()
        {
            string inputData = @"2
                            10
                            17";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
