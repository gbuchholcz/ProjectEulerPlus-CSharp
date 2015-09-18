using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler20
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

                BigInteger number = 1;
                for (int i = 2; i <= N; ++i)
                {
                    number = BigInteger.Multiply(number, i);
                }
                long result = 0;
                while (number > 0)
                {
                    BigInteger reminder;
                    number = BigInteger.DivRem(number, 10, out reminder);
                    result += (long)reminder;
                }
                output.WriteLine(result);
            }
        }

        public static void Test()
        {
            string inputData = @"2
3
6";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
