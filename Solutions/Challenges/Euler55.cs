using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler55
    {
        static void main(String[] args)
        {
            using (System.IO.StreamReader input = new System.IO.StreamReader(Console.OpenStandardInput()))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }

        private static long[] pow10 = new long[] {1, 10, 100, 1000, 10000, 100000, 1000000, 10000000, 100000000, 1000000000, 10000000000, 100000000000, 1000000000000,
                                                    10000000000000, 100000000000000, 1000000000000000, 10000000000000000, 100000000000000000, 1000000000000000000};

        private static void Solve(System.IO.TextReader input, System.IO.TextWriter output)
        {
            long N = long.Parse(input.ReadLine());

            Dictionary<long, long> palindromStore = new Dictionary<long, long>();
            long maxPalindrome = 0;
            long maxPalindromeCount = 0;

            for (long i = 1; i <= N; ++i)
            {
                long number = i;
                long[] numberDigits;
                for (long j = 0; j < 61; ++j)
                {
                    numberDigits = ConvertBase(number, 10);
                    if (IsPalindrome(numberDigits))
                    {
                        if (palindromStore.ContainsKey(number))
                        {
                            long c = palindromStore[number] + 1;
                            palindromStore[number] = c;
                            if (c > maxPalindromeCount)
                            {
                                maxPalindromeCount = c;
                                maxPalindrome = number;
                            }
                        }
                        else
                        {
                            palindromStore[number] = 1;
                        }
                        break;
                    }
                    number = ReverseAdd(numberDigits);
                }
            }
            Console.WriteLine(maxPalindrome + " " + maxPalindromeCount);
        }

        private static bool IsPalindrome(long[] n)
        {
            long i = 0;
            long j = n.Length - 1;
            bool isPalindrome = true;

            do
            {
                if (n[i] != n[j])
                {
                    isPalindrome = false;
                    break;
                }
            } while (++i <= --j);

            return isPalindrome;
        }

        static long[] ConvertBase(long n, long b)
        {
            long[] digits = new long[32];

            int i = 0;
            while (n != 0)
            {
                digits[i++] = n % b;
                n = n / b;
            }
            Array.Resize(ref digits, i);
            return digits;
        }

        private static long ReverseAdd(long[] digits)
        {
            long result = 0;
            int lastIndex = digits.Length - 1;
            for (int i = 0; i < digits.Length; ++i)
            {
                result += pow10[i] * digits[i] + pow10[lastIndex - i] * digits[i];
            }
            return result;
        }

        public static void Test()
        {
            string inputData = @"130";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }



    }
}
