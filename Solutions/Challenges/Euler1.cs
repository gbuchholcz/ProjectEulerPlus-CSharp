using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solutions.Challenges
{
    class Euler1
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
                long m = long.Parse(input.ReadLine()) - 1;
                /*
                long sumOfThree = 3 * (((m / 3) + 1) * (m / 3)) / 2;
                long sumOfFive = 5 * (((m / 5) + 1) * (m / 5)) / 2;
                long sumOfFifteen = 15 * (((m / 15) + 1) * (m / 15)) / 2;
                long result = sumOfThree + sumOfFive - sumOfFifteen;
                */

                /*
                * To spare costly divisions ( https://msdn.microsoft.com/en-us/library/ms973852.aspx )
                */
                long tmp1 = m / 3;
                long tmp2 = m / 5;
                long tmp3 = m / 15;
                long result = (tmp1 * tmp1 + tmp1) * 3 + (tmp2 * tmp2 + tmp2) * 5 - (tmp3 * tmp3 + tmp3) * 15;
                result >>= 1;
                output.WriteLine(result);
            }
        }


        public static void Test()
        {
            string inputData = @"2
                                    10
                                    100";

            using (System.IO.StringReader input = new System.IO.StringReader(inputData))
            using (System.IO.StreamWriter output = new System.IO.StreamWriter(Console.OpenStandardOutput()))
            {
                Solve(input, output);
            }
        }
    }
}
