using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler77
    {
        static void main(String[] args)
        {
            using (System.IO.StreamReader input = new System.IO.StreamReader(Console.OpenStandardInput()))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }

        private static int[] primes = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, //0 - 7
                                                23, 29, 31, 37, 41, 43, 47, 53, //8 - 15
                                                59, 61, 67, 71, 73, 79, 83, 89, //16 - 23
                                                97, 101, 103, 107, 109, 113, 127, 131,
                                                137, 139, 149, 151, 157, 163, 167, 173,
                                                179, 181, 191, 193, 197, 199, 211, 223,
                                                227, 229, 233, 239, 241, 251, 257, 263,
                                                269, 271, 277, 281, 283, 293, 307, 311,
                                                313, 317, 331, 337, 347, 349, 353, 359,
                                                367, 373, 379, 383, 389, 397, 401, 409,
                                                419, 421, 431, 433, 439, 443, 449, 457,
                                                461, 463, 467, 479, 487, 491, 499, 503,
                                                509, 521, 523, 541, 547, 557, 563, 569,
                                                571, 577, 587, 593, 599, 601, 607, 613,
                                                617, 619, 631, 641, 643, 647, 653, 659,
                                                661, 673, 677, 683, 691, 701, 709, 719,
                                                727, 733, 739, 743, 751, 757, 761, 769,
                                                773, 787, 797, 809, 811, 821, 823, 827,
                                                829, 839, 853, 857, 859, 863, 877, 881,
                                                883, 887, 907, 911, 919, 929, 937, 941,
                                                947, 953, 967, 971, 977, 983, 991, 997,
                                                1009};

        private static void Solve(System.IO.TextReader input, System.IO.TextWriter output)
        {
            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                int N = int.Parse(input.ReadLine());

                long[,] partialResults = new long[N + 1, primes.Length];

                partialResults[2, 0] = 1;
                partialResults[3, 1] = 1;
                partialResults[4, 0] = 1;

                for (int i = 5; i <= N; ++i)
                {
                    for (int j = 0; primes[j] <= i; ++j)
                    {
                        if (primes[j] == i)
                        {
                            partialResults[i, j]++;
                        }
                        else
                        {
                            for (int k = j; k >= 0; --k)
                            {
                                partialResults[i, j] += partialResults[i - primes[j], k];
                            }
                        }
                    }
                }

                long result = 0;
                for (int i = 0; primes[i] <= N; ++i)
                {
                    result += partialResults[N, i];
                }

                output.WriteLine(result);
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
