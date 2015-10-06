using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Solutions.Challenges
{
    class Euler42
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
                long x = long.Parse(input.ReadLine());
                long sqrt = (long)(Math.Sqrt(1 + 8 * x) + 0.1);
                if (sqrt * sqrt == 1 + 8 * x)
                {
                    output.WriteLine((sqrt - 1) / 2);
                }
                else
                {
                    output.WriteLine(-1);
                }
            }
        }



        public static void Test()
        {
            string inputData = @"3
2
3
55";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }


    }

}
