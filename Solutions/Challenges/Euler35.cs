﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler35
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

            int N = int.Parse(input.ReadLine());
            long sum = 0L;
            foreach(int p in Primes(N + 1))
            {
                int l = NumberLength(p);
                if (l == 1)
                {
                    sum += p; 
                }
                else
                {
                    bool isCircular = true;
                    int c = p;
                    for(int j = 1; j < l; ++j)
                    {
                        c = Rotate(c , l);
                        if (!IsPrime(c))
                        {
                            isCircular = false;
                            break;
                        }

                    }
                    if (isCircular)
                    {
                        sum += p;
                    }
                }
            }
            output.WriteLine(sum);
        }

        private static int[] POW10 = new int[] { 1, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000 };

        public static int Rotate(int n, int len)
        {
            int mag = POW10[len];
            return (10 * n) % mag + (10 * n) / mag;
        }

        public static int NumberLength(int n)
        {
            if (n < 10) return 1;
            if (n < 100) return 2;
            if (n < 1000) return 3;
            if (n < 10000) return 4;
            if (n < 100000) return 5;
            if (n < 1000000) return 6;
            if (n < 10000000) return 7;
            return 8;
        }

        public static void Test()
        {
            string inputData = @"10000";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }

        private static int[] _primes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113
                    , 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293
                    , 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491
                    , 499, 503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659, 661, 673, 677, 683, 691, 701
                    , 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 809, 811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929
                    , 937, 941, 947, 953, 967, 971, 977, 983, 991, 997, 1009};

        public static IEnumerable<int> Primes(int max)
        {
            int len = _primes.Length;
            for (int i = 0; i < len && _primes[i] < max; ++i) yield return _primes[i];
            for (int n = _primes[len - 1]; n < max; n += 2)
            {
                if (IsPrime(n)) yield return n;
            }
        }

        public static bool IsPrime(int n)
        {
            int len = _primes.Length;
            if (n <= _primes[len - 1])
            {
                int pos = Array.BinarySearch(_primes, n);
                if (pos >= 0) return true;
                return false;
            }

            int maxDivisor = (int)Math.Sqrt(n) + 1;
            for (int i = 0; i < len && _primes[i] < maxDivisor; ++i)
            {
                if (n % _primes[i] == 0) return false;
            }
            for (int i = _primes[len - 1] + 2; i < maxDivisor; i += 2)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

    }
}
