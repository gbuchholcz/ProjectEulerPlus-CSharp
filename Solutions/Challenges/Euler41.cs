using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Solutions.Challenges
{
    class Euler41
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

            List<long> result = new List<long>();

            for (int length = 1; length < 10; ++length)
            {
                foreach (var permutation in Permutate(length))
                {
                    int lastDigit = permutation[length - 1];
                    if (lastDigit == 0 || lastDigit == 2 || lastDigit == 4 || lastDigit == 5 || lastDigit == 6 || lastDigit == 8) continue;
                    long n = ConcatNumber(permutation);
                    if (IsPrime(n))
                    {
                        result.Add(n);
                    }
                }
            }

            result.Sort();

            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                long N = long.Parse(input.ReadLine());
                int pos = result.BinarySearch(N);
                if (pos < 0)
                {
                    pos = ~pos - 1;
                }
                if (pos == -1)
                    output.WriteLine(-1);
                else
                    output.WriteLine(result[pos]);
            }
        }

        private static long ConcatNumber(int[] d)
        {
            long result = 0;
            for (int i = 0; i < d.Length; ++i)
            {
                result *= 10;
                result += d[i];
            }
            return result;
        }

        private static long[] _primes = new long[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113
                    , 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293
                    , 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491
                    , 499, 503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659, 661, 673, 677, 683, 691, 701
                    , 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 809, 811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929
                    , 937, 941, 947, 953, 967, 971, 977, 983, 991, 997, 1009};

        public static bool IsPrime(long n)
        {
            int len = _primes.Length;
            if (n <= _primes[len - 1])
            {
                int pos = Array.BinarySearch(_primes, n);
                if (pos >= 0) return true;
                return false;
            }

            int maxDivisor = (int)Math.Sqrt(n) + 1;
            for (long i = 0; i < len && _primes[i] < maxDivisor; ++i)
            {
                if (n % _primes[i] == 0) return false;
            }
            for (long i = _primes[len - 1] + 2; i < maxDivisor; i += 2)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        private static IEnumerable<int[]> Permutate(int count)
        {
            int[] a = Enumerable.Range(1, count).ToArray();
            int N = a.Length;
            int[] p = new int[N];
            yield return a;
            int i = 1, tmp;
            while (i < N)
            {
                if (p[i] < i)
                {
                    int j = i % 2 * p[i];

                    tmp = a[j];
                    a[j] = a[i];
                    a[i] = tmp;

                    yield return a;
                    ++p[i];
                    i = 1;
                }
                else
                {
                    p[i] = 0;
                    ++i;
                }
            }
        }

        public static void Test()
        {
            string inputData = @"2
100
10000";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }


    }

}
