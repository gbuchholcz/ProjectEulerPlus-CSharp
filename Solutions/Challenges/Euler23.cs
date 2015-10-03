using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler23
    {

        static void main(String[] args)
        {
            using (System.IO.StreamReader input = new System.IO.StreamReader(Console.OpenStandardInput()))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }

        private static int[] primes = new[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131
                                                , 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269
                                                , 271, 277, 281, 283, 293, 307, 311, 313 };

        private const int maxNumber = 100000;

        private static void Solve(System.IO.TextReader input, System.IO.TextWriter output)
        {
            long[] abundantNumbers;
            List<long> abundantNumberList = new List<long>();
            for (int i = 2; i <= maxNumber; ++i)
            {
                long sum1 = CalculateSigma1(FactorNumber(i)) - i;
                if (sum1 > i)
                {
                    abundantNumberList.Add(i);
                }
            }
            abundantNumbers = abundantNumberList.ToArray();

            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                int N = int.Parse(input.ReadLine());
                int left = 0;
                int right = Array.BinarySearch(abundantNumbers, N - abundantNumbers[left]);
                if (right >= 0)
                {
                    output.WriteLine("YES");
                    continue;
                }
                else
                {
                    right = ~right - 1;
                }
                while (left <= right)
                {
                    if (abundantNumbers[left] + abundantNumbers[right] == N)
                    {
                        output.WriteLine("YES");
                        break;
                    }
                    else if (abundantNumbers[left] + abundantNumbers[right] < N)
                    {
                        ++left;
                    }
                    else
                    {
                        --right;
                    }
                }

                if (left > right)
                {
                    output.WriteLine("NO");
                }
            }

        }

        private static long CalculateSigma1(Dictionary<int, int> factors)
        {
            long result = 1;
            foreach (var prime in factors.Keys)
            {
                result *= (Pow(prime, factors[prime] + 1) - 1) / (prime - 1);
            }
            return result;
        }

        private static long Pow(long x, long pow)
        {
            long ret = 1;
            while (pow != 0)
            {
                if ((pow & 1) == 1)
                    ret *= x;
                x *= x;
                pow >>= 1;
            }
            return ret;
        }

        private static Dictionary<int, int> FactorNumber(long n)
        {
            var result = new Dictionary<int, int>();
            long root = (long)Math.Sqrt(n);
            foreach (int prime in primes.Where(p => p <= root))
            {
                while (n % prime == 0)
                {
                    n /= prime;
                    if (result.ContainsKey(prime))
                    {
                        result[prime] += 1;
                    }
                    else
                    {
                        result[prime] = 1;
                    }
                }
            }
            if (n != 1)
            {
                result[(int)n] = 1;
            }
            return result;
        }



        public static void Test()
        {
            string inputData = @"2
24
49";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
