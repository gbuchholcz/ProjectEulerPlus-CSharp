using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler34
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
            long[] faktorials = new long[] { 1, 1, 2, 6, 24, 120, 720, 5040, 40320, 362880 };
            long result = 0;

            for (int number = int.Parse(input.ReadLine()); number > 9; --number)
            {
                int[] numberDigits = ConvertBase(number, 10);
                long sum = 0;
                for (int i = 0; i < numberDigits.Length; ++i)
                {
                    sum += faktorials[numberDigits[i]];
                }
                if (sum % number == 0)
                {
                    result += number;
                }
            }
            output.WriteLine(result);
        }

        static int[] ConvertBase(int n, int b)
        {
            int[] digits = new int[6];

            int i = 0;
            while (n != 0)
            {
                digits[i++] = n % b;
                n = n / b;
            }
            Array.Resize(ref digits, i);
            return digits;
        }

        public static void Test()
        {
            string inputData = @"20";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
