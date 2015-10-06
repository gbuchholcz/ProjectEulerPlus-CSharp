using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Solutions.Challenges
{
    class Euler40
    {

        static void main(String[] args)
        {
            using (System.IO.StreamReader input = new System.IO.StreamReader(Console.OpenStandardInput()))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }

        private static long[] Pow10 = new long[] { 1L, 10L, 100L, 1000L, 10000L, 100000L, 1000000L, 10000000L, 100000000L, 1000000000L, 10000000000L, 100000000000L, 1000000000000L, 10000000000000L, 100000000000000L, 1000000000000000L, 10000000000000000L, 100000000000000000L, 1000000000000000000L };
        private static long[] lowerMargins = new long[20];

        private static void Solve(System.IO.TextReader input, System.IO.TextWriter output)
        {
            lowerMargins[0] = 0;
            lowerMargins[1] = 0;
            for (int numberLength = 2; numberLength < 19; ++numberLength)
            {
                lowerMargins[numberLength] = lowerMargins[numberLength - 1] + (Pow10[numberLength - 1] - Pow10[numberLength - 2]) * (numberLength - 1);
            }


            for (int T = int.Parse(input.ReadLine()); T > 0; --T)
            {
                long product = 1;
                foreach (long pos in input.ReadLine().Split().Select(n => long.Parse(n)))
                {
                    product *= DigitAtPos(pos - 1);
                }
                output.WriteLine(product);
            }
        }



        private static long DigitAtPos(long pos)
        {
            int numberLength = 1;
            for (; pos >= lowerMargins[numberLength]; ++numberLength) ;
            --numberLength;
            long startIndex = lowerMargins[numberLength];
            long startValue = Pow10[numberLength - 1];
            long relPos = pos - startIndex;
            long relValue = startValue + relPos / numberLength;
            long inNumberPos = relPos % numberLength;
            long digit = (relValue / Pow10[numberLength - inNumberPos - 1]) % 10;
            return digit;
        }

        public static void Test()
        {
            string inputData = @"1
1 2 3 4 5 6 7";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }


    }

}
