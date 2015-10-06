using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Solutions.Challenges
{
    class Euler43
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
            var primes = new int[4] { 7, 11, 13, 17 };
            var results = new long[10];
            results[0] = 0;
            results[1] = 0;
            results[2] = 0;
            for (int pan = 3; pan <= 9; ++pan)
            {
                int len = pan + 1;
                long sum = 0;
                foreach (int[] permutation in Permutate(len))
                {
                    if (permutation[3] % 2 != 0) continue;
                    if (len > 4)
                    {
                        if ((permutation[2] + permutation[3] + permutation[4]) % 3 != 0)
                        {
                            continue;
                        }
                        if (len > 5)
                        {
                            if (permutation[5] != 5 && permutation[5] != 0)
                            {
                                continue;
                            }
                            bool isDividable = true;
                            for (int j = 4; j < len - 2; ++j)
                            {

                                if (ConcatNumber(permutation[j], permutation[j + 1], permutation[j + 2]) % primes[j - 4] != 0)
                                {
                                    isDividable = false;
                                    break;
                                }
                            }
                            if (!isDividable)
                            {
                                continue;
                            }
                        }
                    }
                    sum += ConcatNumber(permutation);
                }
                results[pan] = sum;
            }
            int N = int.Parse(input.ReadLine());
            output.WriteLine(results[N]);
        }

        private static long ConcatNumber(int[] d)
        {
            long n = 0;
            for (int i = 0; i < d.Length; ++i)
            {
                n *= 10;
                n += d[i];
            }
            return n;
        }

        private static int ConcatNumber(int d0, int d1, int d2)
        {
            return 100 * d0 + 10 * d1 + d2;
        }

        public static void Test()
        {
            string inputData = @"3";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }

        private static IEnumerable<int[]> Permutate(int count)
        {
            int[] a = Enumerable.Range(0, count).ToArray();
            int N = a.Length;
            int[] p = new int[N];
            yield return a;
            int i = 1;
            int j;
            int tmp;
            while (i < N)
            {
                if (p[i] < i)
                {
                    j = i % 2 * p[i];

                    tmp = a[j];
                    a[j] = a[i];
                    a[i] = tmp;

                    yield return a;
                    p[i]++;
                    i = 1;
                }
                else
                {
                    p[i] = 0;
                    i++;
                }
            }

        }


    }

}
