using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler4
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
            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                int N = int.Parse(input.ReadLine());
                int maxPalindrom = int.MinValue;

                for (int i = 100; i <= 999; ++i)
                {
                    for (int j = i; j <= 999; ++j)
                    {
                        int m = i * j;
                        if (m >= N) continue;
                        if (IsPalindrom(m) && m > maxPalindrom)
                        {
                            maxPalindrom = m;
                        }
                    }
                }
                Console.WriteLine(maxPalindrom);
            }
        }

        private static bool IsPalindrom(int m)
        {
            int[] digits = new int[6];
            for (int i = 0; i < 6; ++i)
            {
                digits[i] = m % 10;
                m /= 10;
            }
            if (digits[5] == digits[0] && digits[4] == digits[1] && digits[3] == digits[2]) return true;
            return false;
        }

        public static void Test()
        {
            string inputData = @"2
                                    101110
                                    800000";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
