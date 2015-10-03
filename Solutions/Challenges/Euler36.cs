using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler36
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
            string[] parameters = input.ReadLine().Split();
            long N = long.Parse(parameters[0]);
            long K = long.Parse(parameters[1]);

            long result = 0;
            for (long i = 1; i < N; ++i)
            {
                if (IsPalindrome(ChangeBase(i, 10L)) && IsPalindrome(ChangeBase(i, K)))
                {
                    result += i;
                }
            }

            output.WriteLine(result);

        }

        public static long[] ChangeBase(long n, long b)
        {
            long[] result = new long[ArrLength(n, b)];
            for (int i = 0; n > 0; result[i++] = n % b, n /= b) ;
            return result;
        }

        public static long ArrLength(long n, long b)
        {
            int result;
            for (result = 0; n > 0; n /= b, ++result) ;
            return result;
        }

        public static bool IsPalindrome(long[] arr)
        {
            int arrLength = arr.Length;
            for (int i = 0; i <= arrLength - i - 1; ++i)
            {
                if (arr[i] != arr[arrLength - i - 1]) return false;
            }
            return true;
        }


        public static void Test()
        {
            string inputData = @"10 2";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
