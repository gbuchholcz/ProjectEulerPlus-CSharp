using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler12
    {
        static void main(String[] args)
        {
            using (System.IO.StreamReader input = new System.IO.StreamReader(Console.OpenStandardInput()))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }

        private static long CalculateNthTriangularNumber(long n)
        {
            if (n % 2 == 0) return n / 2 * (n + 1);
            return (n + 1) / 2 * n;
        }

        private static bool HasNthTriangularNumberMoreDivisorThan(long n, int count)
        {
            long divisorCount = 0;
            if (n % 2 == 0)
            {
                divisorCount = CalculateDivisorCount(n + 1) * CalculateDivisorCount(n / 2);
            }
            else
            {
                divisorCount = CalculateDivisorCount(n) * CalculateDivisorCount((n + 1) / 2);
            }
            return divisorCount > count;
        }

        private static long CalculateDivisorCount(long n)
        {
            if (n == 1) return 1;

            Dictionary<long, int> divisors = new Dictionary<long, int>();
            long maxDivisor = (long)Math.Sqrt(n);

            while (n % 2 == 0)
            {
                n >>= 1;
                if (divisors.ContainsKey(2))
                {
                    divisors[2] += 1;
                }
                else
                {
                    divisors[2] = 1;
                }
            }

            for (long i = 3; i <= maxDivisor; i += 2)
            {
                if (n % i == 0)
                {
                    while (n % i == 0)
                    {
                        n /= i;
                        if (divisors.ContainsKey(i))
                        {
                            divisors[i] += 1;
                        }
                        else
                        {
                            divisors[i] = 1;
                        }
                    }
                }
            }

            if (n != 1)
            {
                divisors[n] = 1;
            }

            int divisorCount = 1;
            foreach (var kvp in divisors)
            {
                divisorCount *= (kvp.Value + 1);
            }
            return divisorCount;
        }

        private static void Solve(System.IO.TextReader input, System.IO.TextWriter output)
        {

            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                int N = int.Parse(input.ReadLine());
                for (int i = 1; ; ++i)
                {
                    if (HasNthTriangularNumberMoreDivisorThan(i, N))
                    {
                        output.WriteLine(CalculateNthTriangularNumber(i));
                        break;
                    }
                }
            }
        }


        public static void Test()
        {
            string inputData = @"4
                                    1
                                    2
                                    3
                                    4";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
